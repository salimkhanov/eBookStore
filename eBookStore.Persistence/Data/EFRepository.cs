using eBookStore.Domain.Entities.Base;
using eBookStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Persistence.Data;

public class EFRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public DbContext _context { get; set; }
    public EFRepository(DbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await Task.Run(() =>
        {
            _context.Set<TEntity>().Update(entity);
        });
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Run(() =>
        {
            _context.Set<TEntity>().Remove(entity);
        });
    }

    public async Task<TEntity> GetSingleOrSingeDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate);
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }



    public async Task<ICollection<TEntity>> GetWheresync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
    }


}
