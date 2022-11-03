using CustomerInformationSystem.Core;
using CustomerInformationSystem.Core.Extensions;
using CustomerInformationSystem.DataAccess.Repositories;
using CustomerInformationSystem.DataAccess.Repositories.Customers;
using CustomerInformationSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Business.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public async Task AddAsync(Customer data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            await _customerRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _customerRepository.DeleteWhere(x => x.Id == id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<Customer>> GetAllAsync(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = _customerRepository
                .GetAll()
                .FindPaged(new PagingParameters() { Page = pageIndex, Limit = pageSize });
            return await query.ToListAsync();
        }

        public async Task<IPagedList<Customer>> GetAllPagedAsync(DateTime? dateFrom = null, DateTime? dateTo = null, int pageIndex = 0, int pageSize = int.MaxValue, string title = null)
        {
            var result = _customerRepository.GetAllPagedAsync(async query =>
            {
                query = query.OrderByDescending(p => p.Id);
                return query;
            }, pageIndex, pageSize);
            return await result;
        }

        public Customer GetById(int id)
        {
            return _customerRepository
                .FindBy(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task UpdateAsync(Customer data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            _customerRepository.Update(data);
            await _unitOfWork.CompleteAsync();
        }
    }
}
