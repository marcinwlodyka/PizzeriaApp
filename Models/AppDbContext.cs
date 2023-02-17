using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PizzeriaApp.Models {
    public class AppDbContext: DbContext {
        public DbSet<Pizza> Menu { get; set; }
        private string DbPath;
        
        public AppDbContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = System.IO.Path.Join(path, "books.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 1, Name = "test1", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" },
                new Pizza() { Id = 2, Name = "test2", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" },
                new Pizza() { Id = 3, Name = "test3", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" }
            );
        }
    }
}