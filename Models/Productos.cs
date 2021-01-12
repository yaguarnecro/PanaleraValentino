namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            CategoriasProducto = new HashSet<CategoriasProducto>();
            Compras = new HashSet<Compras>();
            Devolucion = new HashSet<Devolucion>();
            FacturasVentas = new HashSet<FacturasVentas>();
        }

        [Key]
        [StringLength(10)]
        public string IdProducto { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        public int Costo { get; set; }

        public int Existencia { get; set; }

        [Required]
        [StringLength(25)]
        public string Estado { get; set; }

        [StringLength(25)]
        public string Tipo { get; set; }

        [StringLength(25)]
        public string Tamaño { get; set; }

        [StringLength(25)]
        public string Empaque { get; set; }

        public int PuntoMaximo { get; set; }

        public int PuntoReorden { get; set; }

        public int PuntoMinimo { get; set; }

        [StringLength(25)]
        public string Clasificacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaVencimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriasProducto> CategoriasProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras> Compras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Devolucion> Devolucion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasVentas> FacturasVentas { get; set; }
    }
}
