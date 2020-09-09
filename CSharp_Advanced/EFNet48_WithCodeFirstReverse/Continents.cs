namespace EFNet48_WithCodeFirstReverse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Continents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Continents()
        {
            Countries = new HashSet<Countries>();
        }

        
        public Guid Id { get; set; }

        //[Required]
        [StringLength(50)] // Data-Annotations -> Alternative: FluentAPI 
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Countries> Countries { get; set; }
    }
}
