using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Domain.Models
{
    public class Ingredient
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public int Weight { get; private set; }

        public Ingredient(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
