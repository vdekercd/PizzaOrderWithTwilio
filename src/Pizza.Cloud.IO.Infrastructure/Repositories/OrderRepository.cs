using Microsoft.EntityFrameworkCore;
using Pizza.Cloud.IO.Domain.Interfaces;
using Pizza.Cloud.IO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderWithPizzasByPhoneNumberAsync(string phoneNumber)
        {
            var order = await _context.Orders
                            .Where(order => order.PhoneNumber == phoneNumber && order.OrderDate.Date == DateTime.Today)
                            .FirstOrDefaultAsync();

            LoadChildrens(order);
            return order;
        }

        public async Task<ICollection<Order>> GetTodayConfirmedOrdersAsync()
        {
            var orders = await _context.Orders
                .Where(order => order.IsConfirmed && order.OrderDate.Date == DateTime.Today)
                .ToListAsync();

            orders.ForEach(LoadChildrens);
            return orders;
        }

        private async void LoadChildrens(Order order)
        {
            if (order == null) return;
            await _context.Entry(order).Collection(order => order.Pizzas).LoadAsync();
        }
    }
}
