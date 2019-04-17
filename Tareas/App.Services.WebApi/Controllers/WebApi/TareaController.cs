using App.Domain.DTO;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.Services.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace App.Services.WebApi.Controllers
{
    /// <summary>
    /// Api para realizar distintas acciones en una tarea como
    /// consultar,crear,actualizar y borrrar
    /// </summary>
    [Authorize]
    [RoutePrefix("tareas")]
    public class TareaController: ApiController
    {
        private readonly ITareaService tareaService;
        public TareaController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

        /// <summary>
        /// Permite consultar tareas
        /// Consultar todas las tareas (incluidas las de otros usuarios)
        /// Consultar solo mis tareas(las de usuario autenticado)
        /// Consultar solo tareas finalizadas, solo las que están pendientes o todas sin importar su
        /// estado de finalización.
        /// Ordenar la consultar por fecha de vencimiento.
        /// Combinar la anteriores.
        /// </summary>
        /// <param name="request">Lista de tareas</param>
        /// <returns></returns>
        [HttpGet]
        [Route("consultar")]
        public TareaGetAllResponse Get([FromUri] TareaGetAllRequest request)
        {
            if (request != null)
            {
                if (request.SoloMisTareas)
                {
                    request.UserAuthenticatedID = CommonFunctions.GetUserID();
                }
                else
                {

                    request.UserAuthenticatedID = null;
                }
            }

           return tareaService.GetAll(request);
        }

        [HttpPost]
        [Route("crear")]
        public CommonEntityResponse<Tarea> Create([FromBody] CommonEntityRequest<Tarea> request)
        {
            request.UserAuthenticatedID = CommonFunctions.GetUserID();

            return tareaService.Create(request);
        }

        [HttpPost]
        [Route("actualizar")]
        public TareaUpdateResponse Update([FromBody] TareaUpdateRequest request)
        {
            request.UserAuthenticatedID = CommonFunctions.GetUserID();

            return tareaService.Update(request);
        }

        [HttpPost]
        [Route("borrar")]
        public TareaDeleteResponse Delete([FromBody] TareaDeleteRequest request)
        {
            request.UserAuthenticatedID = CommonFunctions.GetUserID();

            return tareaService.Delete(request);
        }

    }
}