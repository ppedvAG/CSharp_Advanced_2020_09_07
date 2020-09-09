namespace EFNet48_WithCodeFirstReverse
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    //Model1 -> GeoDBContext
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=GeoDBContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Continents> Continents { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Continents>().Property(n => n.Name).HasMaxLength(50);


            modelBuilder.Entity<Continents>()
                .HasMany(e => e.Countries)
                .WithOptional(e => e.Continents)
                .HasForeignKey(e => e.ContinentId);



            
        }
    }
}
