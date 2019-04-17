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
    [Authorize]
    [RoutePrefix("tareas")]
    public class TareaController: ApiController
    {
        private readonly ITareaService tareaService;
        public TareaController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

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