namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Tarea")]
    public partial class Tarea
    {
        public int TareaID { get; set; }

        public DateTime FechaCreacion { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int AutorTareaID { get; set; }

        public Usuario AutorTarea { get; set; }

    }
}
