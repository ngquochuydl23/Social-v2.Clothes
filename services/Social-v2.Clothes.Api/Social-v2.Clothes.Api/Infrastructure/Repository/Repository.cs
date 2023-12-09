using Social_v2.Clothes.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Social_v2.Clothes.Api.Infrastructure.Repository
{

  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {

    private readonly ID3DatabaseContext _appDbContext;

    public Repository(ID3DatabaseContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public ID3DatabaseContext DbContext() => _appDbContext;
    private DbSet<TEntity> _entity => _appDbContext.Set<TEntity>();
    public virtual IQueryable<TEntity> GetQueryableNoTracking() => _entity.AsNoTracking();

    public virtual IQueryable<TEntity> GetQueryable() => _entity.AsQueryable();

    public virtual void Delete(long key)
    {
      var dbEntity = _entity.Find(key);
      if (dbEntity == null)
        throw new NullReferenceException();

      _entity.Remove(dbEntity);
      SaveChange(dbEntity);
    }

    public virtual void Delete(TEntity entity)
    {
      if (entity == null)
        throw new NullReferenceException();

      _entity.Remove(entity);
      SaveChange(entity);
    }

    public virtual TEntity Find(long? key)
    {
      return _entity.Find(key);
    }

    public virtual TEntity Insert(TEntity entity)
    {
      if (entity is IHasCreationTime)
      {
        var hasCreationTimeEntity = (IHasCreationTime)entity;
        hasCreationTimeEntity.CreateAt = DateTime.Now;
      }

      _entity.Add(entity);
      _appDbContext.Entry(entity).State = EntityState.Added;

      SaveChange(entity);
      return entity;
    }
    public TEntity[] InsertMany(TEntity[] entities)
    {
      entities.Select(x =>
      {
        if (x is IHasCreationTime)
        {
          var hasCreationTimeEntity = (IHasCreationTime)x;
          hasCreationTimeEntity.CreateAt = DateTime.Now;
        }
        _appDbContext.Entry(x).State = EntityState.Added;
        return x;
      });

      _entity.AddRange(entities);

      SaveChanges();
      return entities;
    }


    public virtual TEntity Update(long key, TEntity entity)
    {
      if (entity == null)
        throw new NullReferenceException();

      if (entity is ILastUpdatedTime)
      {
        var lastUpdatedTime = (ILastUpdatedTime)entity;
        lastUpdatedTime.LastUpdate = DateTime.Now;
      }
      _appDbContext.Entry(entity).State = EntityState.Modified;
      SaveChange(entity);
      return entity;
    }

    protected virtual void SaveChange(TEntity entity)
    {
      _appDbContext.SaveChanges();
    }

    protected virtual void SaveChanges()
    {
      _appDbContext.SaveChanges();
    }

    public void DeleteRange(TEntity[] entities)
    {
      _entity.RemoveRange(entities);

      SaveChanges();
    }

  }
}
