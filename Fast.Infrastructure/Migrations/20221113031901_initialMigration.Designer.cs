﻿// <auto-generated />
using System;
using Fast.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fast.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221113031901_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Fast.Core.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Extencion")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<int>("IdOrden")
                        .HasColumnType("integer");

                    b.Property<long>("SizeFile")
                        .HasColumnType("bigint");

                    b.Property<string>("UriString")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.HasIndex("IdOrden");

                    b.ToTable("files");
                });

            modelBuilder.Entity("Fast.Core.Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Alto")
                        .HasColumnType("double precision");

                    b.Property<double>("Ancho")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("FechaRealizacionDeseada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("Localizacion")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("MaterialBarda")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Organizacion")
                        .HasColumnType("integer");

                    b.Property<string>("Tematica")
                        .HasMaxLength(516)
                        .HasColumnType("character varying(516)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdUser");

                    b.ToTable("ordenes");
                });

            modelBuilder.Entity("Fast.Core.Entities.OrdenComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Calificacion")
                        .HasMaxLength(5)
                        .HasColumnType("real");

                    b.Property<string>("Comentario")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("IdOrden")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdOrden");

                    b.HasIndex("IdUser");

                    b.ToTable("comentarios");
                });

            modelBuilder.Entity("Fast.Core.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EsVoluntario")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("GoogleUUID")
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<bool>("Suscrito")
                        .HasColumnType("boolean");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Fast.Core.Entities.File", b =>
                {
                    b.HasOne("Fast.Core.Entities.Orden", "IdOrdenNavigation")
                        .WithMany("Files")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdOrdenNavigation");
                });

            modelBuilder.Entity("Fast.Core.Entities.Orden", b =>
                {
                    b.HasOne("Fast.Core.Entities.Usuario", "IdUserNavigation")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Fast.Core.Entities.OrdenComment", b =>
                {
                    b.HasOne("Fast.Core.Entities.Orden", "IdOrdenNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fast.Core.Entities.Usuario", "IdUserNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdOrdenNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Fast.Core.Entities.Orden", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("Fast.Core.Entities.Usuario", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ordenes");
                });
#pragma warning restore 612, 618
        }
    }
}
