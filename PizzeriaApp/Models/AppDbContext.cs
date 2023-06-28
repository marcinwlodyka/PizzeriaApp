using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PizzeriaApp.Models;

public class AppDbContext : DbContext
{
    private readonly string _dbPath;

    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Size> Sizes { get; set; }

    public AppDbContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);

        _dbPath = System.IO.Path.Join(path, "pizzeria.db");
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);

        _dbPath = System.IO.Path.Join(path, "pizzeria.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza()
            {
                Id = 1, Name = "Test0", Price = 10.50f
            },
            new Pizza()
            {
                Id = 2, Name = "Test0", Price = 12.50f
            },
            new Pizza()
            {
                Id = 3, Name = "Test0", Price = 14.50f
            }
        );

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient() { Id = 1, Name = "Tomato Sauce" },
            new Ingredient() { Id = 2, Name = "Cheese" },
            new Ingredient() { Id = 3, Name = "Ham" }
        );

        modelBuilder.Entity<Pizza>()
            .HasMany(p => p.Ingredients)
            .WithMany(i => i.Pizzas)
            .UsingEntity(join => join.HasData(
                new { PizzasId = 1, IngredientsId = 1 },
                new { PizzasId = 1, IngredientsId = 2 },
                new { PizzasId = 1, IngredientsId = 3 },
                new { PizzasId = 2, IngredientsId = 1 },
                new { PizzasId = 2, IngredientsId = 2 },
                new { PizzasId = 3, IngredientsId = 1 }
            ));

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(i => i.Order);

        modelBuilder.Entity<Size>().HasData(
            new Size() { Id = 1, Name = "Small", PriceMultiplier = 1 },
            new Size() { Id = 2, Name = "Medium", PriceMultiplier = 1.25f },
            new Size() { Id = 3, Name = "Large", PriceMultiplier = 1.5f }
        );

        modelBuilder.Entity<Size>()
            .HasMany(s => s.OrderItems)
            .WithOne(i => i.Size);
    }
}