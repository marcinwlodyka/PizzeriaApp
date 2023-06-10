using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PizzeriaApp.Models;
using PizzeriaApp.Services;

namespace PizzeriaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PizzaService _pizzaService;

        public MainWindow()
        {
            _pizzaService = new PizzaService();

            InitializeComponent();
            _getItems();
        }

        private static string _formatIngredients(IEnumerable<Ingredient> ingredients) =>
            string.Join(", ", ingredients.Select(i => i.Name));

        private async void _getItems()
        {
            var pizzas = await _pizzaService.Get();

            PizzasList.ItemsSource = pizzas.Select(p => new {
                Name = p.Name,
                Ingredients = _formatIngredients(p.Ingredients),
                Price = $"{p.Price:0.00} zł"
            });
        }
    }
}