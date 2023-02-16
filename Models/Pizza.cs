using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PizzeriaApp.Models {
    public class Pizza {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Image { get; set; }
    }
}
