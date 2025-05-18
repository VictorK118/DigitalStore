using System.Linq.Expressions;
using DigitalStore.DataAccess;
using DigitalStore.DataAccess.Entities;
using DigitalStore.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DigitalStore.Repository;

public class Repository<T>: IRepository<T> where T: class, IBaseEntity
{
    private readonly IDbContextFactory<DigitalStoreDbContext> _contextFactory;

    public Repository(IDbContextFactory<DigitalStoreDbContext> contextFactory) 
        => _contextFactory = contextFactory;

    public IEnumerable<T> GetAll()
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().AsNoTracking().ToList();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().AsNoTracking().Where(predicate).ToList();
    }

    public T? GetById(int id)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public T? GetById(Guid id)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().FirstOrDefault(x => x.ExternalId == id);
    }

    public T Save(T entity)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        if (dbContext.Set<T>().Any(x => x.Id == entity.Id))
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = entity.CreationTime;
            var result = dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        dbContext.Set<T>().Remove(entity);
        dbContext.SaveChanges();
    }
}