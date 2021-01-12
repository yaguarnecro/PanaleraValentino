namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            Compras = new HashSet<Compras>();
            FacturasVentas = new HashSet<FacturasVentas>();
        }

        [Key]
        [StringLength(10)]
        public string IdEmpleado { get; set; }

        [StringLength(25)]
        public string PrimerNombre { get; set; }

        [StringLength(25)]
        public string SegundoNombre { get; set; }

        [StringLength(25)]
        public string PrimerApellido { get; set; }

        [StringLength(25)]
        public string SegundoApellido { get; set; }

        public int? Edad { get; set; }

        [StringLength(11)]
        public string Telefono { get; set; }

        [StringLength(25)]
        public string Direccion { get; set; }

        [StringLength(10)]
        public string TipoEmpleado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras> Compras { get; set; }

        public virtual TipoEmpleados TipoEmpleados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasVentas> FacturasVentas { get; set; }
    }
}
