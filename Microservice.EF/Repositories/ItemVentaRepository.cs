using Domain.Contracts.Repositories;
using Domain.Entities;
using Microservice.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.EF.Repositories
{
    public class ItemVentaRepository : GenericRepository<ItemVenta>, IItemVentaRepository
    {
        public ItemVentaRepository(EntitiesContext context) : base(context)
        {

        }
    }
}
