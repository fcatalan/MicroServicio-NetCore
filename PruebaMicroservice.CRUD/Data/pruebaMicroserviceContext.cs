using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaMicroservice.CRUD.Models;

#nullable disable

namespace PruebaMicroservice.CRUD.Data
{
    public partial class pruebaMicroserviceContext : DbContext
    {
        public pruebaMicroserviceContext()
        {
        }

        public pruebaMicroserviceContext(DbContextOptions<pruebaMicroserviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CargaBipRetail> CargaBipRetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=pruebaMicroservice;User=sa;Password=PasswordPrueba|1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CargaBipRetail>(entity =>
            {
                entity.ToTable("CargaBipRetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comuna)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Entidad)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioReferencial)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreFantasia)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
