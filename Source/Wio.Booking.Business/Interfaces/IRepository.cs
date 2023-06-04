using System.Linq.Expressions;
using Wio.Booking.Business.Models;

namespace Wio.Booking.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Remover(Guid id);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}