using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorApp.Data.Model
{
    public partial class Adventureworks2017Context : DbContext
    {
        public Adventureworks2017Context()
        {
        }

        public Adventureworks2017Context(DbContextOptions<Adventureworks2017Context> options)
            : base(options)
        {
        }

        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId)
                    .HasName("PK_SalesOrderHeader_SalesOrderID");

                entity.ToTable("SalesOrderHeader", "Sales");

                entity.HasComment("General sales order information.");

                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.SalesOrderId)
                    .HasColumnName("SalesOrderID")
                    .HasComment("Primary key.");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasComment("Customer identification number. Foreign key to Customer.BusinessEntityID.");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Dates the sales order was created.");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.")
                    .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}