using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerInformationSystem.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }

        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params string[] includeProperties) where T : class, new()
        {
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }

        public static IQueryable<T> FindPaged<T>(this IQueryable<T> query, PagingParameters filter)
        {
            return query.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit);
        }

        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            if (source == null)
                return new PagedList<T>(new List<T>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = await source.CountAsync();

            var data = new List<T>();

            if (!getOnlyTotalCount)
                data.AddRange(await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());

            return new PagedList<T>(data, pageIndex, pageSize, count);
        }

        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IList<T> list, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            // If source lisr is null or empty, return empty paged list.
            if (list == null || list.Count == 0)
            {
                IPagedList<T> emptyPagedList = new PagedList<T>(new List<T>(), pageIndex, pageSize);
                return Task.FromResult(emptyPagedList);
            }

            // If pageIndex is less than 1, make it 1.
            pageSize = Math.Max(pageSize, 1);

            // If pageIndex is greater than total page count, make it equal to total page count.
            if (!getOnlyTotalCount)
                list = list.Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToList();

            // Return paged list.
            IPagedList<T> pagedList = new PagedList<T>(list, pageIndex, pageSize, list.Count);
            return Task.FromResult(pagedList);
        }
    }
}
