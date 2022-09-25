using Microservice.EF.Data;
using System;
using Domain.Contracts.UnitOfWork;
using Domain.Contracts.Repositories;

namespace Microservice.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext _context;

        public IItemVentaRepository ItemVentaRepository { get; }


        public UnitOfWork(EntitiesContext context,
           IItemVentaRepository itemsVentasRepository)
        {
            _context = context;
            ItemVentaRepository = itemsVentasRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
