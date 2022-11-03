using CustomerInformationSystem.Core;
using CustomerInformationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Business.Services
{
    public interface IService<T> where T : class, IEntity, new()
    {
        T GetById(int id);
        Task AddAsync(T data);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(T data);
        Task<IList<T>> GetAllAsync(int pageIndex = 1, int pageSize = Int32.MaxValue);
        Task<IPagedList<T>> GetAllPagedAsync(DateTime? dateFrom = null, DateTime? dateTo = null,
            int pageIndex = 0, int pageSize = int.MaxValue, string title = null);
    }
}
