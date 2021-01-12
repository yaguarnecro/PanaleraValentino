namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Compras
    {
        [Key]
        [StringLength(10)]
        public string IdCompra { get; set; }

        [Required]
        [StringLength(10)]
        public string IdProveedor { get; set; }

        [Required]
        [StringLength(10)]
        public string IdProducto { get; set; }

        [StringLength(10)]
        public string IdEmpleado { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int PrecioTotal { get; set; }

        public virtual Productos Productos { get; set; }

        public virtual Proveedores Proveedores { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}
