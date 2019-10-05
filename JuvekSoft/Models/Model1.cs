namespace JuvekSoft.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<FacetingType> FacetingTypes { get; set; }
        public virtual DbSet<InsertMaterial> InsertMaterials { get; set; }
       // public virtual DbSet<InsertStoreModel> InsertStoreModels { get; set; }
        public virtual DbSet<InsertStore> InsertStores { get; set; }
        public virtual DbSet<MetalName> MetalNames { get; set; }
        public virtual DbSet<MetalStore> MetalStores { get; set; }
        public virtual DbSet<MetalType> MetalTypes { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacetingType>()
                .HasMany(e => e.InsertStores)
                .WithRequired(e => e.FacetingType)
                .HasForeignKey(e => e.FacType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsertMaterial>()
                .HasMany(e => e.InsertStores)
                .WithRequired(e => e.InsertMaterial)
                .HasForeignKey(e => e.InsMat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsertStore>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InsertStore>()
                .HasMany(e => e.Products)
                .WithMany(e => e.InsertStores)
                .Map(m => m.ToTable("InsertStoresProducts"));

            modelBuilder.Entity<MetalName>()
                .HasMany(e => e.MetalStores)
                .WithRequired(e => e.MetalName)
                .HasForeignKey(e => e.MetName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MetalStore>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MetalStore>()
                .HasMany(e => e.Products)
                .WithMany(e => e.MetalStores)
                .Map(m => m.ToTable("ProductsMetalStores"));

            modelBuilder.Entity<MetalType>()
                .HasMany(e => e.MetalStores)
                .WithRequired(e => e.MetalType)
                .HasForeignKey(e => e.MetType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operation>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Operation>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Operations)
                .Map(m => m.ToTable("ProductsOperations"));

            modelBuilder.Entity<Product>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.InsertStores)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.QuantityUnits)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.InsertStores1)
                .WithRequired(e => e.Unit1)
                .HasForeignKey(e => e.SizeUnits)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.InsertStores2)
                .WithRequired(e => e.Unit2)
                .HasForeignKey(e => e.CostUnits)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.MetalStores)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.CostUnits)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.MetalStores1)
                .WithRequired(e => e.Unit1)
                .HasForeignKey(e => e.QuantityUnits)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.MetalStores2)
                .WithRequired(e => e.Unit2)
                .HasForeignKey(e => e.SizeUnits)
                .WillCascadeOnDelete(false);
        }
    }
}
