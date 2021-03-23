﻿// <auto-generated />
using System;
using Cupcakes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cupcakes.Migrations
{
    [DbContext(typeof(CupcakeContext))]
    [Migration("20210323222246_1st")]
    partial class _1st
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cupcakes.Models.Bakery", b =>
                {
                    b.Property<int>("BakeryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BakeryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BakeryID");

                    b.ToTable("Bakeries");

                    b.HasData(
                        new
                        {
                            BakeryID = 1,
                            Address = "635 Brighton Circle Road",
                            BakeryName = "Gluteus Free",
                            Quantity = 8
                        },
                        new
                        {
                            BakeryID = 2,
                            Address = "4323 Jerome Avenue",
                            BakeryName = "Cupcakes Break",
                            Quantity = 22
                        },
                        new
                        {
                            BakeryID = 3,
                            Address = "2553 Pin Oak Drive",
                            BakeryName = "Cupcakes Ahead",
                            Quantity = 18
                        },
                        new
                        {
                            BakeryID = 4,
                            Address = "1608 Charles Street",
                            BakeryName = "Sugar",
                            Quantity = 30
                        });
                });

            modelBuilder.Entity("Cupcakes.Models.Cupcake", b =>
                {
                    b.Property<int>("CupcakeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BakeryID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("CupcakeType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GlutenFree")
                        .HasColumnType("bit");

                    b.Property<string>("ImageMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PhotoFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("CupcakeID");

                    b.HasIndex("BakeryID");

                    b.ToTable("Cupcakes");

                    b.HasData(
                        new
                        {
                            CupcakeID = 1,
                            BakeryID = 1,
                            CupcakeType = 0,
                            Description = "Vanilla cupcake with coconut cream",
                            GlutenFree = true,
                            ImageMimeType = "image/jpeg",
                            ImageName = "birthday-cupcake.jpg",
                            Price = 2.5
                        },
                        new
                        {
                            CupcakeID = 2,
                            BakeryID = 2,
                            CupcakeType = 2,
                            Description = "Chocolate cupcake with caramel filling and chocolate butter cream",
                            GlutenFree = false,
                            ImageMimeType = "image/jpeg",
                            ImageName = "chocolate-cupcake.jpg",
                            Price = 3.2000000000000002
                        },
                        new
                        {
                            CupcakeID = 3,
                            BakeryID = 3,
                            CupcakeType = 3,
                            Description = "Chocolate cupcake with straberry cream filling",
                            GlutenFree = false,
                            ImageMimeType = "image/jpeg",
                            ImageName = "pink-cupcake.jpg",
                            Price = 4.0
                        },
                        new
                        {
                            CupcakeID = 4,
                            BakeryID = 4,
                            CupcakeType = 1,
                            Description = "Vanilla cupcake with butter cream",
                            GlutenFree = true,
                            ImageMimeType = "image/jpeg",
                            ImageName = "turquoise-cupcake.jpg",
                            Price = 1.5
                        });
                });

            modelBuilder.Entity("Cupcakes.Models.Cupcake", b =>
                {
                    b.HasOne("Cupcakes.Models.Bakery", "Bakery")
                        .WithMany("Cupcakes")
                        .HasForeignKey("BakeryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bakery");
                });

            modelBuilder.Entity("Cupcakes.Models.Bakery", b =>
                {
                    b.Navigation("Cupcakes");
                });
#pragma warning restore 612, 618
        }
    }
}
