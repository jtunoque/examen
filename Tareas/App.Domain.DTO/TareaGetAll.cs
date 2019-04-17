using App.Entities.Base;
using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class TareaGetAllRequest:CommonRequest
    {
        public bool SoloMisTareas { get; set; }
        public bool? Estado { get; set; }

    }

    public class TareaGetAllResponse: CommonListResponse<TareaQuery>
    {
    }
}
