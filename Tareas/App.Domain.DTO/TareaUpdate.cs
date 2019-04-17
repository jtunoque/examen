using App.Entities.Base;
using App.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class TareaUpdateRequest:CommonRequest
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaVencimiento { get; set; }

    }

    public class TareaUpdateResponse: CommonEntityResponse<Tarea>
    {
    }
}
