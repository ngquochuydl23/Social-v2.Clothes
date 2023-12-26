namespace Social_v2.Clothes.Api.Infrastructure.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity Find(long? key);

        TEntity Insert(TEntity entity);

        TEntity Update(long key, TEntity entity);

        void Delete(long key);

        void Delete(TEntity entity);

        IQueryable<TEntity> GetQueryableNoTracking();

        IQueryable<TEntity> GetQueryable();

        ClothesDbContext DbContext();


        void SaveChanges();

    }
}
