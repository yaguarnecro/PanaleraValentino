namespace PoyectoFinalPañaleraValentino.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Garantia")]
    public partial class Garantia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Garantia()
        {
            Devolucion = new HashSet<Devolucion>();
        }

        [Key]
        [StringLength(10)]
        public string IdGarantia { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public bool? EstadoActivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Devolucion> Devolucion { get; set; }
    }
}
