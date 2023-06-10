using eBookStore.Domain.Entities.Base;
using System.Linq.Expressions;

namespace eBookStore.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    TEntity GetById(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    void Add(TEntity entity);
    void Update(TEntity entity);
    public void UpdateRange(IEnumerable<TEntity> entities);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
