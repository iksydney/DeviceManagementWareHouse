using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IRepository
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task InsertRangeAsync(IEnumerable<T> entities, bool saveNow = true);
        Task InsertAsync(T entity, bool saveNow = true);
        void UpdateRange(IEnumerable<T> entities, bool saveNow = true);
    }
}
