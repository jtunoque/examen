using App.Domain.DTO;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface ITareaService
    {
        TareaGetAllResponse GetAll(TareaGetAllRequest request);

        CommonEntityResponse<Tarea> Create(CommonEntityRequest<Tarea> request);

        TareaUpdateResponse Update(TareaUpdateRequest request);

        TareaDeleteResponse Delete(TareaDeleteRequest request);
    }
}
