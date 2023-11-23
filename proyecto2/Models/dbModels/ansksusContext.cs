using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyecto2.Models.dbModels
{
    public partial class ansksusContext : IdentityDbContext<AplicationUser,IdentityRole<int>,int>
    {
        public ansksusContext()
        {
        }

        public ansksusContext(DbContextOptions<ansksusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cuestionario> Cuestionarios { get; set; } = null!;
        public virtual DbSet<CuestionarioActivo> CuestionarioActivos { get; set; } = null!;
        public virtual DbSet<ImagenesPerfil> ImagenesPerfils { get; set; } = null!;
        public virtual DbSet<ParticipanteEnCuestionario> ParticipanteEnCuestionarios { get; set; } = null!;
        public virtual DbSet<Pregunta> Preguntas { get; set; } = null!;
        public virtual DbSet<Respuesta> Respuestas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__8A3D240C8F6227BC");
            });

            modelBuilder.Entity<Cuestionario>(entity =>
            {
                entity.HasKey(e => e.IdCuestionario)
                    .HasName("PK__cuestion__4A5CFD1B822640FC");

                entity.Property(e => e.Titulo).HasDefaultValueSql("('title')");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Cuestionarios)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuestionario_categoria");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cuestionarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuestionario_usuario");
            });

            modelBuilder.Entity<CuestionarioActivo>(entity =>
            {
                entity.Property(e => e.IdCuestionario).ValueGeneratedNever();

                entity.HasOne(d => d.IdCuestionarioNavigation)
                    .WithOne(p => p.CuestionarioActivo)
                    .HasForeignKey<CuestionarioActivo>(d => d.IdCuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuestionarioA_cuestionario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.CuestionarioActivo)
                    .HasForeignKey<CuestionarioActivo>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuestionarioActivo_usuarios");
            });

            modelBuilder.Entity<ImagenesPerfil>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__imagenes__27CC26894DE81741");

                entity.Property(e => e.IdImagen).ValueGeneratedNever();
            });

            modelBuilder.Entity<ParticipanteEnCuestionario>(entity =>
            {
                entity.HasKey(e => e.IdPeC)
                    .HasName("PK__Particip__3D78D123FAB54659");

                entity.Property(e => e.CantidadPacertadas).HasDefaultValueSql("((0))");

                entity.Property(e => e.Puntos).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCuestionarioActivoNavigation)
                    .WithMany(p => p.ParticipanteEnCuestionarios)
                    .HasForeignKey(d => d.IdCuestionarioActivo)
                    .HasConstraintName("FK_ParticipanteEnCuestionario_cuestionarioActivo1");
            });

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                    .HasName("PK__pregunta__6867FFA45AFDA0E8");

                entity.HasOne(d => d.IdCuestionarioNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdCuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_preguntas_cuestionario");
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.HasKey(e => e.IdRespuesta)
                    .HasName("PK__respuest__14E55589836F7548");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.RespuestaNavigation)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_respuesta_pregunta");
            });

      

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
