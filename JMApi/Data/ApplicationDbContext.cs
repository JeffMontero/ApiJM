using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JMApi.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.0.2.66;Database=JMCOL;user id=sql_service;password=GrupoL@@r2015;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.Property(e => e.Calificacion).HasColumnType("decimal(2, 0)");

                entity.HasOne(d => d.IdColegioNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdColegio)
                    .HasConstraintName("FK__Calificac__IdCol__22AA2996");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("FK__Calificac__IdMat__239E4DCF");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Calificac__IdUsu__24927208");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.ToTable("Colegio");

                entity.HasIndex(e => e.Nombre, "UQ__Colegio__75E3EFCF023D5A04")
                    .IsUnique();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoColegio)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasIndex(e => e.Nombre, "UQ__Materia__75E3EFCF08EA5793")
                    .IsUnique();

                entity.Property(e => e.Area)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Curso)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.DocenteAsignado)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Paralelo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdColegioNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdColegio)
                    .HasConstraintName("FK__Materia__IdColeg__0AD2A005");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Username, "UQ__Usuario__536C85E41CF15040")
                    .IsUnique();

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.Username)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
