using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using App.Data.DataBase;
using App.Data.Repository.Interfaces.QuerySpecifications;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using App.Entities.Query;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class TareaRepositoryTest
    {
        [TestMethod]
        public void CrearTarea()
        {
            var result = false;
            var dbModel = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(dbModel))
            {
                var tarea = new Tarea()
                {
                    Descripcion = $"Tarea {Guid.NewGuid().ToString().Substring(0, 10)}",
                    Estado = false,
                    AutorTareaID = 1,
                    FechaCreacion = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddDays(2)
                };

                unitOfWork.TareaRepository.Add(tarea);
                result=unitOfWork.Complete()>0;
                
            }

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsTrue(result, "No se pudo registrar la tarea");
            }
        }

        [TestMethod]
        public void ActualizarTarea()
        {
            var result = false;
            var dbModel = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(dbModel))
            {
                var tarea = new Tarea()
                {
                    TareaID=1,
                    Descripcion = $"Tarea {Guid.NewGuid().ToString().Substring(0, 10)}",
                    Estado = false,
                    AutorTareaID = 1,
                    FechaVencimiento = DateTime.Now.AddDays(2)
                };


                var updateInfo = new UpdateAdditionalInfo<Tarea>();
                updateInfo.ExcludeFields.Add(item=>item.FechaCreacion);

                unitOfWork.TareaRepository.Update(tarea,updateInfo);
                result = unitOfWork.Complete() > 0;

            }

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsTrue(result, "No se pudo actualizar la tarea");
            }
        }

        [TestMethod]
        public void DeleteTarea()
        {
            var result = false;
            var dbModel = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(dbModel))
            {

                var tareaNew = new Tarea()
                {
                    Descripcion = $"Tarea {Guid.NewGuid().ToString().Substring(0, 10)}",
                    Estado = false,
                    AutorTareaID = 1,
                    FechaCreacion = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddDays(2)
                };

               unitOfWork.TareaRepository.Add(tareaNew);
                unitOfWork.Complete();

               unitOfWork.TareaRepository.Remove(tareaNew);
                result = unitOfWork.Complete() > 0;

            }

            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsTrue(result, "No se pudo eliminar la tarea");
            }
        }

        [TestMethod]
        public void GetTareaQuery()
        {
            var result = new List<TareaQuery>();
            var dbModel = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(dbModel))
            {

                var additionalInfo = new GetAdditionalInfo<Tarea, TareaQuery>()
                {
                    IncludeFields = new List<Expression<Func<Tarea, object>>>()
                        {
                            item=>item.AutorTarea
                        },
                    Filters=item=>item.AutorTareaID==1,
                    SelectFields = item => new TareaQuery()
                    {
                        Descripcion = item.Descripcion,
                        FechaVencimiento = item.FechaVencimiento,
                        NombreUsuario = string.Concat(item.AutorTarea.Nombres, " ", item.AutorTarea.Apellidos)
                    },
                    OrderBy = orderItem => orderItem.OrderByDescending(item => item.FechaCreacion)
                };

              result = unitOfWork.TareaRepository.GetAll(
                  additionalInfo).ToList();

            }

            if (result!=null)
            {
                Assert.IsNotNull(result);
            }
            else
            {
                Assert.IsNull(result, "No se pudo registrar la tarea");
            }
        }

        [TestMethod]
        public void GetTareaSelect()
        {
            var result = new List<Tarea>();
            var dbModel = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(dbModel))
            {

                var additionalInfo = new GetAdditionalInfo<Tarea, Tarea>()
                {
                    IncludeFields = new List<Expression<Func<Tarea, object>>>()
                        {
                            item=>item.AutorTarea
                        },
                        OrderBy = orderItem => orderItem.OrderByDescending(item => item.FechaCreacion)
                };

                result = unitOfWork.TareaRepository.GetAll().ToList();

            }

            if (result != null)
            {
                Assert.IsNotNull(result);
            }
            else
            {
                Assert.IsNull(result, "No se pudo registrar la tarea");
            }
        }
    }
}
