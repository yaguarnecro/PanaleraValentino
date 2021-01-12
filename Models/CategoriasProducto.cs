namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoriasProducto")]
    public partial class CategoriasProducto
    {
        [Key]
        [StringLength(10)]
        public string IdCatProductos { get; set; }

        [StringLength(10)]
        public string IdCategoria { get; set; }

        [StringLength(10)]
        public string IdProducto { get; set; }

        public virtual Categorias Categorias { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
