using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SwaggerApi.Models
{
    public partial class FluentValidationFatihCakirogluContext : DbContext
    {
        public FluentValidationFatihCakirogluContext()
        {
        }

        public FluentValidationFatihCakirogluContext(DbContextOptions<FluentValidationFatihCakirogluContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Addresses_CustomerId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
