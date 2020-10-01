using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Domain.Models
{
    public class Pizza
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public TimeSpan PreparationTime { get; private set; }

        public ICollection<Ingredient> Ingredients { get; private set; }

        public Pizza(string name, decimal price, TimeSpan preparationTime)
        {
            Name = name;
            Price = price;
            PreparationTime = preparationTime;                       
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
    }
}
