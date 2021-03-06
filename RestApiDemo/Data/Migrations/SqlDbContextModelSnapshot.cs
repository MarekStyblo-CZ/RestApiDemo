﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApiDemo.Data;

namespace RestApiDemo.Data.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RestApiDemo.Models.DbSets.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hp 110, 2,1 Ghz processor",
                            ImgUri = "products/notebooks/HP/110/img.jpg",
                            Name = "Notebook Hp 110",
                            Price = 5500m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Hp 210, 2,2 Ghz processor",
                            ImgUri = "products/notebooks/HP/210/img.jpg",
                            Name = "Notebook Hp 210",
                            Price = 5600m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Hp 310, 2,3 Ghz processor",
                            ImgUri = "products/notebooks/HP/310/img.jpg",
                            Name = "Notebook Hp 310",
                            Price = 5700m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Hp 410, 2,4 Ghz processor",
                            ImgUri = "products/notebooks/HP/410/img.jpg",
                            Name = "Notebook Hp 410",
                            Price = 5800m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Hp 510, 2,5 Ghz processor",
                            ImgUri = "products/notebooks/HP/510/img.jpg",
                            Name = "Notebook Hp 510",
                            Price = 5900m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Hp 610, 2,6 Ghz processor",
                            ImgUri = "products/notebooks/HP/610/img.jpg",
                            Name = "Notebook Hp 610",
                            Price = 6000m
                        },
                        new
                        {
                            Id = 7,
                            Description = "Hp 710, 2,7 Ghz processor",
                            ImgUri = "products/notebooks/HP/710/img.jpg",
                            Name = "Notebook Hp 710",
                            Price = 6100m
                        },
                        new
                        {
                            Id = 8,
                            Description = "Hp 810, 2,1 Ghz processor",
                            ImgUri = "products/notebooks/HP/810/img.jpg",
                            Name = "Notebook Hp 810",
                            Price = 6200m
                        },
                        new
                        {
                            Id = 9,
                            Description = "Hp 910, 2,2 Ghz processor",
                            ImgUri = "products/notebooks/HP/910/img.jpg",
                            Name = "Notebook Hp 910",
                            Price = 6300m
                        },
                        new
                        {
                            Id = 10,
                            Description = "Hp 1010, 2,3 Ghz processor",
                            ImgUri = "products/notebooks/HP/1010/img.jpg",
                            Name = "Notebook Hp 1010",
                            Price = 6400m
                        },
                        new
                        {
                            Id = 11,
                            Description = "Hp 1110, 2,4 Ghz processor",
                            ImgUri = "products/notebooks/HP/1110/img.jpg",
                            Name = "Notebook Hp 1110",
                            Price = 6500m
                        },
                        new
                        {
                            Id = 12,
                            Description = "Hp 1210, 2,5 Ghz processor",
                            ImgUri = "products/notebooks/HP/1210/img.jpg",
                            Name = "Notebook Hp 1210",
                            Price = 6600m
                        },
                        new
                        {
                            Id = 13,
                            Description = "Hp 1310, 2,6 Ghz processor",
                            ImgUri = "products/notebooks/HP/1310/img.jpg",
                            Name = "Notebook Hp 1310",
                            Price = 6700m
                        },
                        new
                        {
                            Id = 14,
                            Description = "Hp 1410, 2,7 Ghz processor",
                            ImgUri = "products/notebooks/HP/1410/img.jpg",
                            Name = "Notebook Hp 1410",
                            Price = 6800m
                        },
                        new
                        {
                            Id = 15,
                            Description = "Hp 1510, 2,1 Ghz processor",
                            ImgUri = "products/notebooks/HP/1510/img.jpg",
                            Name = "Notebook Hp 1510",
                            Price = 6900m
                        },
                        new
                        {
                            Id = 16,
                            Description = "Hp 1610, 2,2 Ghz processor",
                            ImgUri = "products/notebooks/HP/1610/img.jpg",
                            Name = "Notebook Hp 1610",
                            Price = 7000m
                        },
                        new
                        {
                            Id = 17,
                            Description = "Hp 1710, 2,3 Ghz processor",
                            ImgUri = "products/notebooks/HP/1710/img.jpg",
                            Name = "Notebook Hp 1710",
                            Price = 7100m
                        },
                        new
                        {
                            Id = 18,
                            Description = "Hp 1810, 2,4 Ghz processor",
                            ImgUri = "products/notebooks/HP/1810/img.jpg",
                            Name = "Notebook Hp 1810",
                            Price = 7200m
                        },
                        new
                        {
                            Id = 19,
                            Description = "Hp 1910, 2,5 Ghz processor",
                            ImgUri = "products/notebooks/HP/1910/img.jpg",
                            Name = "Notebook Hp 1910",
                            Price = 7300m
                        },
                        new
                        {
                            Id = 20,
                            Description = "Hp 2010, 2,6 Ghz processor",
                            ImgUri = "products/notebooks/HP/2010/img.jpg",
                            Name = "Notebook Hp 2010",
                            Price = 7400m
                        },
                        new
                        {
                            Id = 21,
                            Description = "Hp 2110, 2,7 Ghz processor",
                            ImgUri = "products/notebooks/HP/2110/img.jpg",
                            Name = "Notebook Hp 2110",
                            Price = 7500m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
