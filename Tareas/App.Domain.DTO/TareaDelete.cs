using App.Entities.Base;
using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class TareaDeleteRequest:CommonRequest
    {
        public int TareaID { get; set; }
    }

    public class TareaDeleteResponse: CommonResponse
    {
    }
}
