using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using App.Domain.DTO;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace App.Services.WebApi.Tests.Controllers
{
    [TestClass]
    public class TareaControllerTest
    {
        private string Address = "";
        private string SecurityToken = "";

        public TareaControllerTest()
        {
            this.Address = ConfigurationManager.AppSettings["WebApiURL"];
            SecurityToken = this.GenerateSecurityToken("user1","user1");
        }

        private string GenerateSecurityToken(string userName,string password)
        {
            var apiURL = $"{Address}/login";
            HttpClient _client = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("userName", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password"),
            });

            var response = _client.PostAsync(apiURL, content).Result;
            var tokenInfo = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;

            if (tokenInfo.ContainsKey("access_token"))
                return tokenInfo["access_token"];
            else
                return "";
        }

        [TestMethod]
        public void ConsultarTodasTareas()
        {
    
            var apiURL = $"{Address}/tareas/consultar";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");

            var response = client.GetAsync(apiURL).Result;
            var resultado = response.Content.ReadAsAsync<TareaGetAllResponse>().Result;

            Assert.IsTrue(resultado.Listado.Count() > 0,"No existen tareas");

        }

       

        [TestMethod]
        public void ConsultarMisTareas()
        {
            var apiURL = $"{Address}/tareas/consultar?SoloMisTareas=true";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");

            var response = client.GetAsync(apiURL).Result;
            var resultado = response.Content.ReadAsAsync<TareaGetAllResponse>().Result;

            Assert.IsTrue(resultado.Listado.Count() > 0,"No existen tareas para el usuario");

        }

        [TestMethod]
        public void ConsultarUsuarioSinTareas()
        {

            var apiURL = $"{Address}/tareas/consultar?SoloMisTareas=true";
            HttpClient client = new HttpClient();
            var secToken = this.GenerateSecurityToken("user2", "user2");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {secToken}");

            var response = client.GetAsync(apiURL).Result;
            var resultado = response.Content.ReadAsAsync<TareaGetAllResponse>().Result;

            Assert.IsTrue(resultado.Listado.Count() == 0, "El usuario tiene tareas");

        }

        [TestMethod]
        public void ConsultarTodasTareasFinalizadas()
        {
            var apiURL = $"{Address}/tareas/consultar?Estado=true";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");

            var response = client.GetAsync(apiURL).Result;
            var resultado = response.Content.ReadAsAsync<TareaGetAllResponse>().Result;

            Assert.IsTrue(resultado.Listado.Count() > 0,"No existen tareas finalizadas");

        }

        [TestMethod]
        public void ConsultarMisTareasFinalizadas()
        {
            var apiURL = $"{Address}/tareas/consultar?SoloMisTareas=true&Estado=true";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");

            var response = client.GetAsync(apiURL).Result;
            var resultado = response.Content.ReadAsAsync<TareaGetAllResponse>().Result;

            Assert.IsTrue(resultado.Listado.Count() > 0, "No existen tareas finalizadas para el usuario");

        }

        [TestMethod]
        public void ConsultarUsuarioSinAcceso()
        {

            var apiURL = $"{Address}/tareas/consultar";
            HttpClient client = new HttpClient();
            var secToken = this.GenerateSecurityToken("user3", "user3");

            var response = client.GetAsync(apiURL).Result;

            Assert.IsTrue(response.StatusCode.GetHashCode()==401, "El usuario tiene acceso al sistema");

        }

        [TestMethod]
        public void ConsultarUsuarioConAcceso()
        {

            var apiURL = $"{Address}/tareas/consultar";
            HttpClient client = new HttpClient();
            var secToken = this.GenerateSecurityToken("user1", "user1");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {secToken}");

            var response = client.GetAsync(apiURL).Result;

            Assert.IsTrue(response.StatusCode.GetHashCode() == 200, "El usuario no tiene acceso al sistema");

        }


        [TestMethod]
        public void CrearTarea()
        {
            var apiURL = $"{Address}/tareas/crear";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");
            var response = client.PostAsJsonAsync(apiURL,
                    new {
                        Entity = new {
                            Descripcion = $"Tarea {Guid.NewGuid().ToString().Substring(0, 10)}",
                            Estado = false,
                            FechaCreacion = DateTime.Now,
                            FechaVencimiento = DateTime.Now.AddDays(2)
                        }
                    }
                ).Result;

            var resultado = response.Content.ReadAsAsync<CommonEntityResponse<Tarea>>().Result;

            Assert.IsTrue(resultado.Entity.TareaID>0, resultado.ErrorMessage);

        }

        [TestMethod]
        public void ActualizarTarea()
        {
            var apiURL = $"{Address}/tareas/actualizar";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");
            var response = client.PostAsJsonAsync(apiURL,
                    new
                    {
                        TareaID = 7,
                        Descripcion="Implementar web services",
                        Estado = true,
                        FechaVencimiento = DateTime.Now.AddDays(2)
                    }
                ).Result;

            var resultado = response.Content.ReadAsAsync<CommonEntityResponse<Tarea>>().Result;

            Assert.IsTrue(resultado.IsOK, resultado.ErrorMessage);

        }

        [TestMethod]
        public void BorrarTarea()
        {

            //Crea una tarea y borra
            var crearApiURL = $"{Address}/tareas/crear";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");
            var crearResponse = client.PostAsJsonAsync(crearApiURL,
                    new
                    {
                        Entity = new
                        {
                            Descripcion = $"Tarea {Guid.NewGuid().ToString().Substring(0, 10)}",
                            Estado = false,
                            FechaCreacion = DateTime.Now,
                            FechaVencimiento = DateTime.Now.AddDays(2)
                        }
                    }
                ).Result;

            //Obteniendo la información de la entidad creada
            var entity = crearResponse.Content.ReadAsAsync<CommonEntityResponse<Tarea>>().Result;

            //Procediendo a eliminar la entidad
            var apiURL = $"{Address}/tareas/borrar";
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.SecurityToken}");
            var response = client.PostAsJsonAsync(apiURL,
                    new{
                        TareaID = entity.Entity.TareaID
                    }
                ).Result;

            var resultado = response.Content.ReadAsAsync<CommonEntityResponse<Tarea>>().Result;

            Assert.IsTrue(resultado.IsOK, resultado.ErrorMessage);

        }


    }
}
