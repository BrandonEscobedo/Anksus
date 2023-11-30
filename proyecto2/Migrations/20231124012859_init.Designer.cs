﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyecto2.Models.dbModels;

#nullable disable

namespace proyecto2.Migrations
{
    [DbContext(typeof(ansksusContext))]
    [Migration("20231124012859_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.AplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("IdImagenPerfil")
                        .HasColumnType("int")
                        .HasColumnName("id_imagen_perfil");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdImagenPerfil");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("Categoria1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("categoria");

                    b.HasKey("IdCategoria")
                        .HasName("PK__categori__8A3D240C8F6227BC");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Cuestionario", b =>
                {
                    b.Property<int>("IdCuestionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_cuestionario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCuestionario"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<bool>("Publico")
                        .HasColumnType("bit")
                        .HasColumnName("publico");

                    b.Property<string>("Titulo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("titulo")
                        .HasDefaultValueSql("('title')");

                    b.HasKey("IdCuestionario")
                        .HasName("PK__cuestion__4A5CFD1B822640FC");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdUsuario");

                    b.ToTable("cuestionarios");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.CuestionarioActivo", b =>
                {
                    b.Property<int>("IdCuestionario")
                        .HasColumnType("int")
                        .HasColumnName("id_cuestionario");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdCuestionario");

                    b.HasIndex(new[] { "Codigo" }, "IX_cuestionarioActivo")
                        .IsUnique();

                    b.HasIndex(new[] { "IdUsuario" }, "IX_cuestionarioActivo_1")
                        .IsUnique();

                    b.ToTable("cuestionarioActivo");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.ImagenesPerfil", b =>
                {
                    b.Property<int>("IdImagen")
                        .HasColumnType("int")
                        .HasColumnName("id_imagen");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("imagen");

                    b.HasKey("IdImagen")
                        .HasName("PK__imagenes__27CC26894DE81741");

                    b.ToTable("imagenes_perfil");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.ParticipanteEnCuestionario", b =>
                {
                    b.Property<int>("IdPeC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPeC");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPeC"), 1L, 1);

                    b.Property<int?>("CantidadPacertadas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("IdCuestionarioActivo")
                        .HasColumnType("int")
                        .HasColumnName("idCuestionarioActivo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<int?>("Puntos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("puntos")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdPeC")
                        .HasName("PK__Particip__3D78D123FAB54659");

                    b.HasIndex("IdCuestionarioActivo");

                    b.HasIndex(new[] { "Nombre" }, "UQ__Particip__72AFBCC655E8C9D6")
                        .IsUnique();

                    b.ToTable("ParticipanteEnCuestionario");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Pregunta", b =>
                {
                    b.Property<int>("IdPregunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_pregunta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPregunta"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<int>("IdCuestionario")
                        .HasColumnType("int")
                        .HasColumnName("id_cuestionario");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("respuesta");

                    b.HasKey("IdPregunta")
                        .HasName("PK__pregunta__6867FFA45AFDA0E8");

                    b.HasIndex("IdCuestionario");

                    b.ToTable("preguntas");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Respuesta", b =>
                {
                    b.Property<int>("IdRespuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_respuesta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRespuesta"), 1L, 1);

                    b.Property<int>("IdPregunta")
                        .HasColumnType("int")
                        .HasColumnName("id_pregunta");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("pregunta");

                    b.Property<bool>("RCorrecta")
                        .HasColumnType("bit")
                        .HasColumnName("R_correcta");

                    b.HasKey("IdRespuesta")
                        .HasName("PK__respuest__14E55589836F7548");

                    b.HasIndex("IdPregunta");

                    b.ToTable("respuestas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proyecto2.Models.dbModels.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.AplicationUser", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.ImagenesPerfil", "IdImagenPerfilNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdImagenPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdImagenPerfilNavigation");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Cuestionario", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.Categoria", "IdCategoriaNavigation")
                        .WithMany("Cuestionarios")
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("FK_cuestionario_categoria");

                    b.HasOne("proyecto2.Models.dbModels.AplicationUser", "IdUsuarioNavigation")
                        .WithMany("Cuestionarios")
                        .HasForeignKey("IdUsuario")
                        .IsRequired()
                        .HasConstraintName("FK_cuestionario_usuario");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.CuestionarioActivo", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.Cuestionario", "IdCuestionarioNavigation")
                        .WithOne("CuestionarioActivo")
                        .HasForeignKey("proyecto2.Models.dbModels.CuestionarioActivo", "IdCuestionario")
                        .IsRequired()
                        .HasConstraintName("FK_CuestionarioA_cuestionario");

                    b.HasOne("proyecto2.Models.dbModels.AplicationUser", "IdUsuarioNavigation")
                        .WithOne("CuestionarioActivo")
                        .HasForeignKey("proyecto2.Models.dbModels.CuestionarioActivo", "IdUsuario")
                        .IsRequired()
                        .HasConstraintName("FK_cuestionarioActivo_usuarios");

                    b.Navigation("IdCuestionarioNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.ParticipanteEnCuestionario", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.CuestionarioActivo", "IdCuestionarioActivoNavigation")
                        .WithMany("ParticipanteEnCuestionarios")
                        .HasForeignKey("IdCuestionarioActivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ParticipanteEnCuestionario_cuestionarioActivo1");

                    b.Navigation("IdCuestionarioActivoNavigation");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Pregunta", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.Cuestionario", "IdCuestionarioNavigation")
                        .WithMany("Pregunta")
                        .HasForeignKey("IdCuestionario")
                        .IsRequired()
                        .HasConstraintName("FK_preguntas_cuestionario");

                    b.Navigation("IdCuestionarioNavigation");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Respuesta", b =>
                {
                    b.HasOne("proyecto2.Models.dbModels.Pregunta", "IdPreguntaNavigation")
                        .WithMany("RespuestaNavigation")
                        .HasForeignKey("IdPregunta")
                        .IsRequired()
                        .HasConstraintName("FK_respuesta_pregunta");

                    b.Navigation("IdPreguntaNavigation");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.AplicationUser", b =>
                {
                    b.Navigation("CuestionarioActivo");

                    b.Navigation("Cuestionarios");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Categoria", b =>
                {
                    b.Navigation("Cuestionarios");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Cuestionario", b =>
                {
                    b.Navigation("CuestionarioActivo");

                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.CuestionarioActivo", b =>
                {
                    b.Navigation("ParticipanteEnCuestionarios");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.ImagenesPerfil", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("proyecto2.Models.dbModels.Pregunta", b =>
                {
                    b.Navigation("RespuestaNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
