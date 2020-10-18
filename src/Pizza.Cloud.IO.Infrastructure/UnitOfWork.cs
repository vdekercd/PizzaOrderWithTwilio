using Pizza.Cloud.IO.Domain.Interfaces;
using Pizza.Cloud.IO.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private IOrderRepository _orderRepository;
        private IPizzaRepository _pizzaRepository;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_databaseContext);

        public IPizzaRepository Pizzas => _pizzaRepository ??= new PizzaRepository(_databaseContext);

        private bool _disposed = false;

        public async Task<bool> SaveAsync()
        {
            return (await _databaseContext.SaveChangesAsync()) > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
