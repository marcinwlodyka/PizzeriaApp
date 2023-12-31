﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaApp.Models;

#nullable disable

namespace PizzeriaApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230217222028_AddOrderFix")]
    partial class AddOrderFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("PizzeriaApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzeriaApp.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg",
                            Ingredients = "ass",
                            Name = "test1"
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg",
                            Ingredients = "ass",
                            Name = "test2"
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg",
                            Ingredients = "ass",
                            Name = "test3"
                        });
                });

            modelBuilder.Entity("PizzeriaApp.Models.Order", b =>
                {
                    b.HasOne("PizzeriaApp.Models.Pizza", "Pizza")
                        .WithMany("Orders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzeriaApp.Models.Pizza", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
