using System.Collections.Generic;
using Quote.Core.Entities;

namespace Quote.Core.Interfaces
{
    public interface IClient<T> where T : BaseEntity
    {

        T GetById(int id);
        T GetById(ISpecification<T> spec);
        // T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        T Attach(T entity);
        List<T> AttachRange(List<T> entity);
        void Delete(T entity);
        void DeleteRange(List<T> entity);
        void SetDelete(T entity);

    }
}

