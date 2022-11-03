using CustomerInformationSystem.Core;
using CustomerInformationSystem.Core.Extensions;
using CustomerInformationSystem.DataAccess.Repositories;
using CustomerInformationSystem.DataAccess.Repositories.CustomerPhoneNumbers;
using CustomerInformationSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Business.Services.CustomerPhoneNumbers
{
    public class CustomerPhoneNumberService : ICustomerPhoneNumberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerPhoneNumberRepository _customerPhoneNumberRepository;

        public async Task AddAsync(CustomerPhoneNumber data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            await _customerPhoneNumberRepository.AddAsync(data);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _customerPhoneNumberRepository.DeleteWhere(x => x.Id == id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<CustomerPhoneNumber>> GetAllAsync(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = _customerPhoneNumberRepository
                .GetAll()
                .FindPaged(new PagingParameters() { Page = pageIndex, Limit = pageSize });
            return await query.ToListAsync();
        }

        public async Task<IPagedList<CustomerPhoneNumber>> GetAllPagedAsync(DateTime? dateFrom = null, DateTime? dateTo = null, int pageIndex = 0, int pageSize = int.MaxValue, string title = null)
        {
            var result = _customerPhoneNumberRepository.GetAllPagedAsync(async query =>
            {
                query = query.OrderByDescending(p => p.Id);
                return query;
            }, pageIndex, pageSize);
            return await result;
        }

        public CustomerPhoneNumber GetById(int id)
        {
            return _customerPhoneNumberRepository
                .FindBy(x => x.Id == id)
                .FirstOrDefault();
        }

        public async Task UpdateAsync(CustomerPhoneNumber data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            _customerPhoneNumberRepository.Update(data);
            await _unitOfWork.CompleteAsync();
        }
    }
}
