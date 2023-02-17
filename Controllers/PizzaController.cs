using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Models;
using Microsoft.Extensions.Logging;

namespace PizzeriaApp.Controllers {
    public class PizzaController : Controller {
        private static AppDbContext _context = new AppDbContext();
        
        public IActionResult Index() => View(_context.Menu.ToList<Pizza>());

        public IActionResult Create() => View();

       [HttpPost] 
        public IActionResult Create([FromForm] Pizza pizza) {
            if (!ModelState.IsValid) return View();

             _context.Menu.Add(pizza);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit([FromRoute] int id) {
            Pizza? foundPizza = _context.Menu.Find(id);

            if (foundPizza is null) return RedirectToAction(nameof(Index));

            return View(foundPizza);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Pizza pizza) {
            if (!ModelState.IsValid) return View();

            Pizza? foundPizza = _context.Menu.Find(pizza.Id);

            if (foundPizza is not null) {
                foundPizza.Name = pizza.Name;
                foundPizza.Ingredients = pizza.Ingredients;
                foundPizza.Image = pizza.Image;

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Delete([FromRoute] int id)
        {
            Pizza? foundPizza = _context.Menu.Find(id);

            if (foundPizza is not null) {
                _context.Menu.Remove(foundPizza);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
