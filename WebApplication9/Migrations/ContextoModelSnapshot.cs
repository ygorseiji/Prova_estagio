﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication9.Models;

namespace WebApplication9.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("WebApplication9.Models.Cliente", b =>
                {
                    b.Property<Guid>("CDCL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CDVEND")
                        .HasColumnType("TEXT");

                    b.Property<float>("DSLIM")
                        .HasColumnType("REAL");

                    b.Property<string>("DSNOME")
                        .HasColumnType("TEXT");

                    b.Property<string>("IDTIPO")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("vendedorCDVEND")
                        .HasColumnType("TEXT");

                    b.HasKey("CDCL");

                    b.HasIndex("vendedorCDVEND");

                    b.ToTable("dbCliente");
                });

            modelBuilder.Entity("WebApplication9.Models.Vendedor", b =>
                {
                    b.Property<Guid>("CDVEND")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CDTAB")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DSNOME")
                        .HasColumnType("TEXT");

                    b.Property<string>("DTNASC")
                        .HasColumnType("TEXT");

                    b.HasKey("CDVEND");

                    b.ToTable("dbVendedor");
                });

            modelBuilder.Entity("WebApplication9.Models.Cliente", b =>
                {
                    b.HasOne("WebApplication9.Models.Vendedor", "vendedor")
                        .WithMany("Clientes")
                        .HasForeignKey("vendedorCDVEND");

                    b.Navigation("vendedor");
                });

            modelBuilder.Entity("WebApplication9.Models.Vendedor", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
