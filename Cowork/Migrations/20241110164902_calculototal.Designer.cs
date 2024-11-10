﻿// <auto-generated />
using System;
using Cowork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cowork.Migrations
{
    [DbContext(typeof(CoworkContext))]
    [Migration("20241110164902_calculototal")]
    partial class calculototal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cowork.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Cowork.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Cowork.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HorarioFim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("SalaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Cowork.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoPorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("FuncionarioReserva", b =>
                {
                    b.Property<int>("FuncionariosId")
                        .HasColumnType("int");

                    b.Property<int>("ReservasId")
                        .HasColumnType("int");

                    b.HasKey("FuncionariosId", "ReservasId");

                    b.HasIndex("ReservasId");

                    b.ToTable("ReservaFuncionarios", (string)null);
                });

            modelBuilder.Entity("Cowork.Models.Reserva", b =>
                {
                    b.HasOne("Cowork.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowork.Models.Sala", "Sala")
                        .WithMany("Reservas")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("FuncionarioReserva", b =>
                {
                    b.HasOne("Cowork.Models.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowork.Models.Reserva", null)
                        .WithMany()
                        .HasForeignKey("ReservasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cowork.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Cowork.Models.Sala", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
