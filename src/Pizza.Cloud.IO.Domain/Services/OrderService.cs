using Pizza.Cloud.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Models.Order> GetOrderWithPizzasByPhoneNumberAsync(string phoneNumber)
        {
            return await _orderRepository.GetOrderWithPizzasByPhoneNumberAsync(phoneNumber) ?? new Models.Order(phoneNumber);
        }
    }
}
