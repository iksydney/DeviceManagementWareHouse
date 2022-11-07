using ContractAndImplementations.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repo;
        //protected readonly DbSet<T> DbSet;
        public RepositoryBase(RepositoryContext repo) => _repo = repo;
        public void Create(T entity) => _repo.Set<T>().Add(entity);
        public void Delete(T entity) => _repo?.Set<T>().Remove(entity); 

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _repo.Set<T>()
            .AsNoTracking() : _repo.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _repo.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            _repo.Set<T>()
            .Where(expression);

        public async Task InsertAsync(T entity, bool saveNow = true) => await _repo.Set<T>().AddAsync(entity);
        public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveNow = true) => await _repo.Set<T>().AddRangeAsync(entities);

        public void Update(T entity) => _repo.Set<T>().Update(entity);

        public void UpdateRange(IEnumerable<T> entities, bool saveNow = true) => _repo.Set<IEnumerable<T>>().UpdateRange(entities);
    }
}
