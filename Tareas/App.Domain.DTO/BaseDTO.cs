using App.Entities.Base;
using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class CommonRequest
    {
        public int? UserAuthenticatedID { get; set; }
    }

    public class CommonEntityRequest<T>:CommonRequest
    {
        public T Entity { get; set; }
    }

    public class CommonResponse
    {
        public bool IsOK { get; set; }
        public string ErrorMessage { get; set; }

    }

    public class CommonListResponse<T>:CommonResponse
    {
        public IEnumerable<T> Listado { get; set; }    
    }

    public class CommonEntityResponse<T> : CommonResponse
    {
        public T Entity { get; set; }
    }
}
