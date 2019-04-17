namespace App.Entities.Query
{
    using System;
    using System.Collections.Generic;
    

    public class TareaQuery
    {
        public int TareaID { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool EstadoTarea { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string NombreUsuario { get; set; }
    }
}
