using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ServerAPI.Contracts;

namespace ServerAPI.Repository
{
public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; } 
        public RepositoryBase(RepositoryContext repositoryContext) 
        {
            RepositoryContext = repositoryContext; 
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

         public async Task AddAsync(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }
    }
}