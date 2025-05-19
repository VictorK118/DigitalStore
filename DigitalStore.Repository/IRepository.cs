using System.Linq.Expressions;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.DataAccess.Repository;

public interface IRepository<T> where T: class, IBaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> SaveAsync(T entity);
    Task DeleteAsync(T entity);
}