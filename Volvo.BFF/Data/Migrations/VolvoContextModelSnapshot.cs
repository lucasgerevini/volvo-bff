﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volvo.BFF.Data;

namespace Volvo.BFF.Data.Migrations
{
    [DbContext(typeof(VolvoContext))]
    partial class VolvoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Volvo.BFF.Models.Caminhao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("SiglaModelo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SiglaModelo");

                    b.ToTable("Caminhoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnoFabricacao = 2021,
                            AnoModelo = 2021,
                            SiglaModelo = "FH"
                        },
                        new
                        {
                            Id = 2,
                            AnoFabricacao = 2021,
                            AnoModelo = 2022,
                            SiglaModelo = "FM"
                        });
                });

            modelBuilder.Entity("Volvo.BFF.Models.Modelo", b =>
                {
                    b.Property<string>("Sigla")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Permitido")
                        .HasColumnType("INTEGER");

                    b.HasKey("Sigla");

                    b.ToTable("Modelos");

                    b.HasData(
                        new
                        {
                            Sigla = "FH",
                            Permitido = true
                        },
                        new
                        {
                            Sigla = "FM",
                            Permitido = true
                        });
                });

            modelBuilder.Entity("Volvo.BFF.Models.Caminhao", b =>
                {
                    b.HasOne("Volvo.BFF.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("SiglaModelo");

                    b.Navigation("Modelo");
                });
#pragma warning restore 612, 618
        }
    }
}
