using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.DomainService
{
    public interface IDSItemVenta
    {
        Task<ItemVenta> Insert(ItemVenta customer);

        ItemVenta Modify(ItemVenta customer);

        void Delete(ItemVenta customer);

        Task<IEnumerable<ItemVenta>> Get(Expression<Func<ItemVenta, bool>> where = null);
    }
}
