using Domain.Contracts.DomainService;
using Domain.Contracts.UnitOfWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DomainService
{
    public class DSItemVenta : IDSItemVenta
    {
        private readonly IUnitOfWork _unitOfWork;

        public DSItemVenta(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(ItemVenta ItemVenta)
        {
            _unitOfWork.ItemVentaRepository.Delete(ItemVenta);

            _unitOfWork.SaveChanges();
        }

        public ItemVenta Modify(ItemVenta ItemVenta)
        {
            var updatedItemVenta = _unitOfWork.ItemVentaRepository.Update(ItemVenta);

            _unitOfWork.SaveChanges();

            return updatedItemVenta;
        }

        public async Task<IEnumerable<ItemVenta>> Get(Expression<Func<ItemVenta, bool>> where = null)
        {
            if (where == null)
                return await _unitOfWork.ItemVentaRepository.GetAll();

            return await _unitOfWork.ItemVentaRepository.Get(where);
        }

        public async Task<ItemVenta> Insert(ItemVenta ItemVenta)
        {
            var savedItemVenta = await _unitOfWork.ItemVentaRepository.Add(ItemVenta);

            _unitOfWork.SaveChanges();

            return savedItemVenta;
        }
    }
}
