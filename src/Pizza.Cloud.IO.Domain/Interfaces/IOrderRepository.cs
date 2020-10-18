﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<ICollection<Models.Order>> GetTodayConfirmedOrdersAsync();
        Task<Models.Order> GetOrderWithPizzasByPhoneNumberAsync(string phoneNumber);
    }
}
