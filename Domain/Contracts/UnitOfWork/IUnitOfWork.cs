using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IItemVentaRepository ItemVentaRepository { get; }

        void SaveChanges();
    }
}
