namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Devolucion")]
    public partial class Devolucion
    {
        [Key]
        [StringLength(10)]
        public string IdDevolucion { get; set; }

        [StringLength(10)]
        public string IdGarantia { get; set; }

        [StringLength(10)]
        public string IdProducto { get; set; }

        public bool? Estado { get; set; }

        [Column(TypeName = "money")]
        public decimal? ValorDevuelto { get; set; }

        public virtual Garantia Garantia { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
