namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FacturasVentas
    {
        [Key]
        [StringLength(10)]
        public string IdFacturaVenta { get; set; }

        [Required]
        [StringLength(10)]
        public string IdProducto { get; set; }

        [Required]
        [StringLength(10)]
        public string IdEmpleado { get; set; }

        public int CedulaCliente { get; set; }

        public int PrecioProducto { get; set; }

        public int Cantidad { get; set; }

        public int PrecioTotal { get; set; }

        public double Iva { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Empleados Empleados { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
