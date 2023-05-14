using eBookStore.Domain.Entities.Base;
using System.Linq.Expressions;

namespace eBookStore.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task RemoveAsync(T entity);

    public Task<T> GetSingleOrSingeDefaultAsync(Expression<Func<T, bool>> predicate);

    public Task<ICollection<T>> GetAllAsync();

    public Task<ICollection<T>> GetWheresync(Expression<Func<T, bool>> predicate);
}