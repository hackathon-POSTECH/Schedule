using Microsoft.EntityFrameworkCore;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInfra.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly ScheduleContext _context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(ScheduleContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().Where(w => w.DeletedAt == null).ToListAsync();

    }

    public async Task AddAsync(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        DbSet.UpdateRange(entities);
        await SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
        await SaveChangesAsync();
    }

    private async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id) ?? new();
    }

}

