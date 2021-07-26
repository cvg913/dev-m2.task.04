using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace dev_m2.task._03.Models
{
    public partial class ElcoBitContext : DbContext
    {
        public ElcoBitContext()
        {
        }

        public ElcoBitContext(DbContextOptions<ElcoBitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EntidaFederativa> EntidaFederativas { get; set; }
        public virtual DbSet<Localidad> Localidades { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("CADENA_DE_CONEXION");
                 optionsBuilder.EnableSensitiveDataLogging();
                 optionsBuilder.EnableDetailedErrors();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EntidaFederativa>(entity =>
            {
                entity.HasKey(e => e.EntidadId);

                entity.ToTable("EntidaFederativa");

                entity.Property(e => e.EntidadId)
                    .ValueGeneratedNever()
                    .HasColumnName("EntidadID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAbreviado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => new { e.EntidadId, e.MunicipioId, e.LocalidadId });

                entity.ToTable("Localidad");

                entity.Property(e => e.EntidadId).HasColumnName("EntidadID");

                entity.Property(e => e.MunicipioId).HasColumnName("MunicipioID");

                entity.Property(e => e.LocalidadId).HasColumnName("LocalidadID");

                entity.Property(e => e.Ambito)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.LatitudDecimal).HasColumnType("decimal(12, 8)");

                entity.Property(e => e.LongitudDecimal).HasColumnType("decimal(12, 8)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Localidads)
                    .HasForeignKey(d => new { d.EntidadId, d.MunicipioId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidad_Municipio");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => new { e.EntidadId, e.MunicipioId });

                entity.ToTable("Municipio");

                entity.Property(e => e.EntidadId).HasColumnName("EntidadID");

                entity.Property(e => e.MunicipioId).HasColumnName("MunicipioID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Entidad)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.EntidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_EntidaFederativa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
