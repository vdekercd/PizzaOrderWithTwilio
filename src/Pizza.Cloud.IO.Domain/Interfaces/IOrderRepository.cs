using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Models.Pizza> GetPizzaByNameAsync(string name);
        Task<ICollection<Models.Order>> GetTodayConfirmedOrdersAsync();
        Task<Models.Order> GetOrderByPhoneNumberAsync(string phoneNumber);
    }
}
