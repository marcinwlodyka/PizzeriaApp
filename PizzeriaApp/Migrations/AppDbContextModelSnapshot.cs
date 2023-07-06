﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaApp.Models;

#nullable disable

namespace PizzeriaApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("IngredientPizza", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredientsId", "PizzasId");

                    b.HasIndex("PizzasId");

                    b.ToTable("IngredientPizza");

                    b.HasData(
                        new
                        {
                            IngredientsId = 1,
                            PizzasId = 1
                        },
                        new
                        {
                            IngredientsId = 2,
                            PizzasId = 1
                        },
                        new
                        {
                            IngredientsId = 3,
                            PizzasId = 1
                        },
                        new
                        {
                            IngredientsId = 1,
                            PizzasId = 2
                        },
                        new
                        {
                            IngredientsId = 2,
                            PizzasId = 2
                        },
                        new
                        {
                            IngredientsId = 1,
                            PizzasId = 3
                        });
                });

            modelBuilder.Entity("PizzeriaApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tomato Sauce"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ham"
                        });
                });

            modelBuilder.Entity("PizzeriaApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzeriaApp.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SizeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.HasIndex("SizeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PizzeriaApp.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Test0",
                            Price = 10.5f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Test0",
                            Price = 12.5f
                        },
                        new
                        {
                            Id = 3,
                            Name = "Test0",
                            Price = 14.5f
                        });
                });

            modelBuilder.Entity("PizzeriaApp.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("PriceMultiplier")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small",
                            PriceMultiplier = 1f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium",
                            PriceMultiplier = 1.25f
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large",
                            PriceMultiplier = 1.5f
                        });
                });

            modelBuilder.Entity("IngredientPizza", b =>
                {
                    b.HasOne("PizzeriaApp.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaApp.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzeriaApp.Models.OrderItem", b =>
                {
                    b.HasOne("PizzeriaApp.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaApp.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaApp.Models.Size", "Size")
                        .WithMany("OrderItems")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzeriaApp.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PizzeriaApp.Models.Size", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}