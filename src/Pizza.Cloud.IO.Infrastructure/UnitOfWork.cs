using Pizza.Cloud.IO.Domain.Interfaces;
using Pizza.Cloud.IO.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Cloud.IO.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext _databaseContext;
        private IOrderRepository _orderRepository;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IOrderRepository CallbackRepository => _orderRepository ??= new OrderRepository(_databaseContext);

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
