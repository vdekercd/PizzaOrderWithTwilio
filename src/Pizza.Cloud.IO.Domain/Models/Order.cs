using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Domain.Models
{
    public class Order
    {
        [Key]
        public int? Id { get; private set; }
        public DateTime OrderDate { get; private set; } 
        public bool IsConfirmed { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime EstimatedWithdrawalTime { get; private set; }

        public ICollection<Pizza> Pizzas { get; private set; }

        public Order(string phoneNumber)
        {
            OrderDate = DateTime.Now;

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty", nameof(phoneNumber));

            PhoneNumber = phoneNumber;
        }

        public void AddPizza(Pizza pizza)
        {
            if (pizza == null)
                throw new ArgumentException(nameof(pizza));

            Pizzas.Add(pizza);
        }

        //TODO : Nice to have - Feature to remove a pizza

        public void SetEstimatedWithdrawalTime(DateTime estimatedWithdrawalTime)
        {
            EstimatedWithdrawalTime = estimatedWithdrawalTime;
        }
    }
}
