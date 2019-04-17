using App.Data.Repository;
using App.Data.Repository.Interfaces;
using App.Data.Repository.Interfaces.QuerySpecifications;
using App.Domain.DTO;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class TareaService : ITareaService
    {
        public CommonEntityResponse<Tarea> Create(CommonEntityRequest<Tarea> request)
        {
            var result = new CommonEntityResponse<Tarea>();

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    request.Entity.AutorTareaID = request.UserAuthenticatedID.Value;
                    unitOfWork.TareaRepository.Add(request.Entity);
                    unitOfWork.Complete();

                    if (request.Entity.TareaID == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        result.IsOK = true;
                        result.Entity = request.Entity;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error al crear la tarea";
                result.IsOK = false;
            }

            return result;
        }

        public TareaDeleteResponse Delete(TareaDeleteRequest request)
        {
            var result = new TareaDeleteResponse();

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {


                    var tareaFound = unitOfWork.TareaRepository.GetAll(
                        new GetAdditionalSimpleInfo<Tarea>()
                        {
                            Filters = item => item.TareaID == request.TareaID
                                              && item.AutorTareaID == request.UserAuthenticatedID
                        }).FirstOrDefault();

                    if (tareaFound != null)
                    {
                        unitOfWork.TareaRepository.Remove(tareaFound);
                        unitOfWork.Complete();
                        result.IsOK = true;
                    }
                    else
                    {
                        result.IsOK = false;
                        result.ErrorMessage = "No está permitido eliminar una tarea que fue creada por otro usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error al eliminar la tarea";
                result.IsOK = false;
            }

            return result;
        }

        public TareaGetAllResponse GetAll(TareaGetAllRequest request)
        {
            var result=new TareaGetAllResponse();

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    

                    var getAdditionalInfo = new GetAdditionalInfo<Tarea, TareaQuery>();
                    if (request != null)
                    {
                        int? autorTareaID = request.UserAuthenticatedID;

                        getAdditionalInfo.Filters = item => (autorTareaID == null || item.AutorTareaID == autorTareaID)
                                                    && (request.Estado == null || item.Estado == request.Estado);
                    }

                    getAdditionalInfo.OrderBy = order => order.OrderBy(item => item.FechaVencimiento);
                    getAdditionalInfo.SelectFields = item => new TareaQuery()
                    {
                        TareaID = item.TareaID,
                        Descripcion = item.Descripcion,
                        FechaCreacion = item.FechaCreacion,
                        EstadoTarea = item.Estado,
                        FechaVencimiento = item.FechaVencimiento,
                        NombreUsuario = string.Concat(item.AutorTarea.Nombres, " ", item.AutorTarea.Apellidos)
                    };
                    getAdditionalInfo.IncludeFields = new List<Expression<Func<Tarea, object>>>() { item => item.AutorTarea };

                    result.Listado = unitOfWork.TareaRepository.GetAll(getAdditionalInfo);
                    result.IsOK = true;

                }

            }
            catch(Exception ex)
            {
                result.ErrorMessage = "Error al obtener información de tareas";
                result.IsOK = false;
            }

            return result;
        }

        public TareaUpdateResponse Update(TareaUpdateRequest request)
        {
            var result = new TareaUpdateResponse();

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {


                    var tareaFound = unitOfWork.TareaRepository.GetAll(
                        new GetAdditionalSimpleInfo<Tarea>()
                        {
                            Filters = item => item.TareaID == request.TareaID
                                              && item.AutorTareaID == request.UserAuthenticatedID
                        }).FirstOrDefault();

                    if (tareaFound != null)
                    {
                        var isUpdate = false;

                        var updateInfo = new UpdateAdditionalInfo<Tarea>();
                        //Excluyendo fecha creación
                        updateInfo.ExcludeFields.Add(item => item.FechaCreacion);
                        //Excluyendo el autor
                        updateInfo.ExcludeFields.Add(item => item.AutorTareaID);

                        //Verificando si hay que actualizar la descripción
                        if (String.IsNullOrWhiteSpace(request.Descripcion))
                        {
                            updateInfo.ExcludeFields.Add(item => item.Descripcion);
                        }
                        else
                        {
                            isUpdate = true;
                            tareaFound.Descripcion = request.Descripcion;
                        }

                        //Verificando si hay que actualizar la fecha vencimiento
                        if (!request.FechaVencimiento.HasValue)
                        {
                            updateInfo.ExcludeFields.Add(item => item.FechaVencimiento);
                        }
                        else
                        {
                            isUpdate = true;
                            tareaFound.FechaVencimiento = request.FechaVencimiento.Value;
                        }

                        //Verificando si hay que actualizar la fecha vencimiento
                        if (!request.Estado.HasValue)
                        {
                            updateInfo.ExcludeFields.Add(item => item.Estado);
                        }
                        else
                        {
                            isUpdate = true;
                            tareaFound.Estado = request.Estado.Value;
                        }


                        if (isUpdate)
                        {                           
                            unitOfWork.TareaRepository.Update(tareaFound, updateInfo);
                            unitOfWork.Complete();
                            result.IsOK = true;
                        }
                        else
                        {
                            result.IsOK = false;
                            result.ErrorMessage = "Debe indicar los datos de la tarea que desea actualizar";
                        }
                    }
                    else
                    {
                        result.IsOK = false;
                        result.ErrorMessage = "No está permitido actualizar la tarea que fue creada por otro usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error al crear la tarea";
                result.IsOK = false;
            }

            return result;
        }
    }
}
