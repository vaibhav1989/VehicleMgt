using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VehicleMgt.Models
{
    public partial class VFactoryDBContext : DbContext
    {
        public VFactoryDBContext()
        {
        }

        public VFactoryDBContext(DbContextOptions<VFactoryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<ConfigurationValue> ConfigurationValue { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=VFactoryDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ConfigurationValue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasMaxLength(200);
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ProductionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Model_Manufacturer");
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Colour)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicles_Model");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
