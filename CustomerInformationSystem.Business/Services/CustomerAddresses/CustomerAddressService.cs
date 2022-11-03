using CustomerInformationSystem.Core;
using CustomerInformationSystem.Core.Extensions;
using CustomerInformationSystem.DataAccess.Repositories;
using CustomerInformationSystem.DataAccess.Repositories.CustomerAddresses;
using CustomerInformationSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Business.Services.CustomerAddresses
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public async Task AddAsync(CustomerAddress data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            await _customerAddressRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _customerAddressRepository.DeleteWhere(x => x.Id == id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<CustomerAddress>> GetAllAsync(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = _customerAddressRepository
                .GetAll()
                .FindPaged(new PagingParameters() { Page = pageIndex, Limit = pageSize });
            return await query.ToListAsync();
        }

        public async Task<IPagedList<CustomerAddress>> GetAllPagedAsync(DateTime? dateFrom = null, DateTime? dateTo = null, int pageIndex = 0, int pageSize = int.MaxValue, string title = null)
        {
            var result = _customerAddressRepository.GetAllPagedAsync(async query =>
            {
                query = query.OrderByDescending(p => p.Id);
                return query;
            }, pageIndex, pageSize);
            return await result;
        }

        public CustomerAddress GetById(int id)
        {
            return _customerAddressRepository
                .FindBy(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task UpdateAsync(CustomerAddress data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            _customerAddressRepository.Update(data);
            await _unitOfWork.CompleteAsync();
        }
    }
}
