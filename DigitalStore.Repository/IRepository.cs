using System.Linq.Expressions;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.DataAccess.Repository;

public interface IRepository<T> where T: class, IBaseEntity
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetById(int id);
    T? GetById(Guid id);
    T Save(T entity);
    void Delete(T entity);
}