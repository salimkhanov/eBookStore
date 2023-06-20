using eBookStore.Domain.Entities.Base;
using eBookStore.Domain.Repositories;
using System.Linq.Expressions;
using System;
using eBookStore.Persistence.Data;

namespace eBookStore.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly eBookStoreContext _eBookStoreContext;
    public BaseRepository(eBookStoreContext eBookStoreContext)
    {
        _eBookStoreContext = eBookStoreContext;
    }
    public BaseRepository()
    {
        _eBookStoreContext = new eBookStoreContext();
    }
    public void Add(TEntity entity)
    {
        _eBookStoreContext.Set<TEntity>().Add(entity);
        _eBookStoreContext.SaveChanges();
    }
    public void AddRange(IEnumerable<TEntity> entities)
    {
        _eBookStoreContext.Set<TEntity>().AddRange(entities);
        _eBookStoreContext.SaveChanges();
    }
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
    {
        return _eBookStoreContext.Set<TEntity>().Where(expression);
    }
    public IEnumerable<TEntity> GetAll()
    {
        return _eBookStoreContext.Set<TEntity>().OrderBy(c => c.Id).ToList();
    }
    public TEntity GetById(int id)
    {
        return _eBookStoreContext.Set<TEntity>().Find(id);
    }
    public void Remove(TEntity entity)
    {
        _eBookStoreContext.Set<TEntity>().Remove(entity);
        _eBookStoreContext.SaveChanges();
    }
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _eBookStoreContext.Set<TEntity>().RemoveRange(entities);
        _eBookStoreContext.SaveChanges();
    }
    public void Update(TEntity entity)
    {
        _eBookStoreContext.Set<TEntity>().Update(entity);
        _eBookStoreContext.SaveChanges();
    }
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _eBookStoreContext.Set<TEntity>().UpdateRange(entities);
        _eBookStoreContext.SaveChanges();
    }
    public void Deactivate(TEntity entity)
    {
        entity.EntityStatus = Domain.Enums.EntityStatus.Deactive;
        _eBookStoreContext.Set<TEntity>().Update(entity);
        _eBookStoreContext.SaveChanges();
    }
    public void Activate(TEntity entity)
    {
        entity.EntityStatus = Domain.Enums.EntityStatus.Active;
        _eBookStoreContext.Set<TEntity>().Update(entity);
        _eBookStoreContext.SaveChanges();
    }
    public IEnumerable<TEntity> GetAllForDropDown()
    {
        return _eBookStoreContext.Set<TEntity>().OrderBy(c => c.Id).ToList();
    }
}