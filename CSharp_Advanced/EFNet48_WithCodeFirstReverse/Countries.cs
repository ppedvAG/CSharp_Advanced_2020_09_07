namespace EFNet48_WithCodeFirstReverse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Countries
    {
        public Guid Id { get; set; }

        public Guid? ContinentId { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        public virtual Continents Continents { get; set; }
    }
}
