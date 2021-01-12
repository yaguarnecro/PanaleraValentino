namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            FacturasVentas = new HashSet<FacturasVentas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cedula { get; set; }

        [Required]
        [StringLength(10)]
        public string IdTipocliente { get; set; }

        [StringLength(25)]
        public string PrimerNombre { get; set; }

        [StringLength(25)]
        public string SegundoNombre { get; set; }

        [StringLength(25)]
        public string PrimerApellido { get; set; }

        [StringLength(25)]
        public string SegundoApellido { get; set; }

        [StringLength(11)]
        public string Telefono { get; set; }

        [StringLength(50)]
        public string CorreoElectronico { get; set; }

        public virtual Tipoclientes Tipoclientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasVentas> FacturasVentas { get; set; }
    }
}
