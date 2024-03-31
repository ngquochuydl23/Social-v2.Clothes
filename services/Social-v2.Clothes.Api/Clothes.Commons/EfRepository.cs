using Clothes.Commons.Seedworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons
{
    public class EfRepository<TEntity, TIdKey> : IEfRepository<TEntity, TIdKey>
        where TEntity : class
    {
        private readonly DbContext _appDbContext;

        public EfRepository(DbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private DbSet<TEntity> _entity => _appDbContext.Set<TEntity>();

        public void Delete(TIdKey key)
        {
            var dbEntity = _entity.Find(key);
            if (dbEntity == null)
                throw new NullReferenceException();

            if (dbEntity is IDeleteEntity)
            {
                var deletedEntity = (IDeleteEntity)dbEntity;
                deletedEntity.IsDeleted = true;
            }
            _appDbContext.Entry(dbEntity).State = EntityState.Modified;
            SaveChanges();
        }

        public TEntity Find(TIdKey? key)
        {
            return _entity.Find(key);
        }

        public DbContext GetDbContext()
        {
            return _appDbContext;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _entity.AsTracking();
        }

        public IQueryable<TEntity> GetQueryableNoTracking()
        {
            return _entity.AsNoTracking();
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity is IHasCreationTime)
            {
                var hasCreationTimeEntity = (IHasCreationTime)entity;
                hasCreationTimeEntity.CreatedAt = DateTime.Now;
            }

            _entity.Add(entity);
            _appDbContext.Entry(entity).State = EntityState.Added;

            SaveChanges();
            return entity;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public TEntity Update(TIdKey key, TEntity entity)
        {
            if (entity == null)
                throw new NullReferenceException();

            if (entity is ILastUpdatedTime)
            {
                var lastUpdatedTime = (ILastUpdatedTime)entity;
                lastUpdatedTime.LastUpdated = DateTime.Now;
            }
            _appDbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }
    }
}
