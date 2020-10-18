using Microsoft.EntityFrameworkCore;
using Pizza.Cloud.IO.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Infrastructure.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly DatabaseContext _context;

        public PizzaRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Domain.Models.Pizza> GetPizzaByNameAsync(string name)
        {
            return await _context.Pizzas
                    .Where(pizza => String.Compare(pizza.Name, name, StringComparison.OrdinalIgnoreCase) == 0)
                    .FirstOrDefaultAsync();
        }
    }
}
