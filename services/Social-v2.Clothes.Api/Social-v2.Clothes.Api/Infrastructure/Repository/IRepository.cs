namespace Social_v2.Clothes.Api.Infrastructure.Repository
{
  public interface IRepository<TEntity>
  {
    TEntity Find(long? key);

    TEntity Insert(TEntity entity);

    TEntity[] InsertMany(TEntity[] entities);

    TEntity Update(long key, TEntity entity);

    void Delete(long key);

    void Delete(TEntity entity);

    void DeleteRange(TEntity[] entities);

    IQueryable<TEntity> GetQueryableNoTracking();

    IQueryable<TEntity> GetQueryable();

    ClothesDbContext DbContext();

    void SaveChanges();
  }
}
