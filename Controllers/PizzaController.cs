using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Models;
using Microsoft.Extensions.Logging;

namespace PizzeriaApp.Controllers
{
    public class PizzaController : Controller
    {
        public static Dictionary<int, Pizza> menu = new Dictionary<int, Pizza> {
            { 1, new Pizza() { Id = 1, Name = "test1", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" } },
            { 2, new Pizza() { Id = 2, Name = "test2", Ingredients = "ass", Image="https://obiaddlataty.pl/wp-content/uploads/2020/02/domowa_pizza-scaled.jpg" } },
            { 3, new Pizza() { Id = 3, Name = "test3", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" } },
            { 4, new Pizza() { Id = 3, Name = "test3", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" } },
            { 5, new Pizza() { Id = 3, Name = "test3", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" } },
            { 6, new Pizza() { Id = 3, Name = "test3", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" } },
            { 7, new Pizza() { Id = 3, Name = "test3", Ingredients = "ass", Image="https://cdn.aniagotuje.com/pictures/articles/2022/08/31553098-v-1500x1500.jpg" } },
        };

        public IActionResult Index()
        {
            return View(menu);
        }
    }
}