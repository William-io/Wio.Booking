using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wio.Booking.Business.Interfaces;
using Wio.Booking.Business.Models;
using Wio.Booking.Data.Context;

namespace Wio.Booking.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly DataContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(DataContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAll() => await DbSet.ToListAsync();

    public async Task<TEntity> GetById(Guid id) => await DbSet.FindAsync(id) ?? throw new InvalidOperationException("Entity not found.");

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate) => await DbSet.AsNoTracking().Where(predicate).ToListAsync();

    public virtual async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remover(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges() => await Db.SaveChangesAsync();

    public void Dispose() => Db?.Dispose();
}