﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240419155313_modificacionpropiedadocumentos")]
    partial class modificacionpropiedadocumentos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("FechaNacimiento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Cuenta", b =>
                {
                    b.Property<long>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Identificador"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<double>("Saldo")
                        .HasColumnType("double precision");

                    b.HasKey("Identificador");

                    b.ToTable("Cuentas", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("integer");

                    b.Property<double>("Pago")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("IdPrestamo");

                    b.ToTable("Cuotas", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("integer");

                    b.Property<int>("IdTipo")
                        .HasColumnType("integer");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("documento")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("IdPrestamo");

                    b.HasIndex("IdTipo");

                    b.ToTable("Documentos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.EstadoPrestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.HasKey("Id");

                    b.ToTable("EstadoPrestamos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.FechaActual", b =>
                {
                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.ToTable("FechaActual", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("CuentaOrigenIdentificador")
                        .HasColumnType("bigint");

                    b.Property<long>("CuentaReceptoraIdentificador")
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Monto")
                        .HasColumnType("double precision");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("Movimientos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("CuentaIdentificador")
                        .HasColumnType("bigint");

                    b.Property<int>("CuotaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CuentaIdentificador");

                    b.HasIndex("CuotaId");

                    b.ToTable("Pagos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Plazo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MaximaCuotas")
                        .HasColumnType("integer");

                    b.Property<int>("MinimoCuotas")
                        .HasColumnType("integer");

                    b.Property<double>("Porcentaje")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Plazos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("CuotaMensual")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<int>("IdEstado")
                        .HasColumnType("integer");

                    b.Property<int>("IdPlazo")
                        .HasColumnType("integer");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("double precision");

                    b.Property<int>("NumeroCuotas")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdPlazo");

                    b.ToTable("Prestamos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("TiposDocumentos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("TipoMovimientos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Cuota", b =>
                {
                    b.HasOne("Core.Entidades.Prestamo", "prestamo")
                        .WithMany()
                        .HasForeignKey("IdPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("prestamo");
                });

            modelBuilder.Entity("Core.Entidades.Documento", b =>
                {
                    b.HasOne("Core.Entidades.Prestamo", "prestamo")
                        .WithMany()
                        .HasForeignKey("IdPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.TipoDocumento", "Tipo")
                        .WithMany()
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");

                    b.Navigation("prestamo");
                });

            modelBuilder.Entity("Core.Entidades.Movimiento", b =>
                {
                    b.HasOne("Core.Entidades.TipoMovimiento", "TipoMovimiento")
                        .WithMany()
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("Core.Entidades.Pago", b =>
                {
                    b.HasOne("Core.Entidades.Cuenta", "CuentaOrigen")
                        .WithMany()
                        .HasForeignKey("CuentaIdentificador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Cuota", "CuotaPagada")
                        .WithMany()
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaOrigen");

                    b.Navigation("CuotaPagada");
                });

            modelBuilder.Entity("Core.Entidades.Prestamo", b =>
                {
                    b.HasOne("Core.Entidades.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.EstadoPrestamo", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Plazo", "plazo")
                        .WithMany()
                        .HasForeignKey("IdPlazo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("cliente");

                    b.Navigation("plazo");
                });
#pragma warning restore 612, 618
        }
    }
}
