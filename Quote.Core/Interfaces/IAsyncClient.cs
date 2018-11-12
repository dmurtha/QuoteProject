using Quote.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quote.Core.Interfaces
{
    public interface IAsyncClient<T> where T : BaseEntity
    {

        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(ISpecification<T> spec);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void DeleteRangeAsync(List<T> entity);
        T Attach(T entity);
        List<T> AttachRange(List<T> entity);
        void SetDelete(T entity);
    }
}
