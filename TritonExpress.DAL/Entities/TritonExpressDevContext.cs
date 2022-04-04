using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TritonExpress.DAL.Entities
{
    public partial class TritonExpressDevContext : DbContext
    {
        public TritonExpressDevContext()
        {
        }

        public TritonExpressDevContext(DbContextOptions<TritonExpressDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<ReceiversInformation> ReceiversInformations { get; set; }
        public virtual DbSet<ShippersInformation> ShippersInformations { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleWayBillRef> VehicleWayBillRefs { get; set; }
        public virtual DbSet<WayBill> WayBills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TritonExpressConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.ToTable("Charge");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkWayBillId).HasColumnName("FK_WayBillID");

                entity.Property(e => e.TotalCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalWeightInKgs).HasColumnName("TotalWeightInKGs");
            });

            modelBuilder.Entity<ReceiversInformation>(entity =>
            {
                entity.ToTable("ReceiversInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActualShipmentReceivedByDate).HasColumnType("datetime");

                entity.Property(e => e.FkWayBillId).HasColumnName("FK_WayBillID");

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverCompanyName)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverContactName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShippersInformation>(entity =>
            {
                entity.ToTable("ShippersInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActualShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.FkWayBillId).HasColumnName("FK_WayBillID");

                entity.Property(e => e.ShipperAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ShipperCompanyName)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ShipperContactName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkBranchId).HasColumnName("FK_BranchID");

                entity.Property(e => e.LicensePlateNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleWayBillRef>(entity =>
            {
                entity.ToTable("Vehicle_WayBill_Ref");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkVehicleId).HasColumnName("FK_VehicleID");

                entity.Property(e => e.FkWayBillId).HasColumnName("FK_WayBillID");
            });

            modelBuilder.Entity<WayBill>(entity =>
            {
                entity.ToTable("WayBill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveredByDate).HasColumnType("datetime");

                entity.Property(e => e.DescriptionOfContent)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentOfCharge)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpByDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(24)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
