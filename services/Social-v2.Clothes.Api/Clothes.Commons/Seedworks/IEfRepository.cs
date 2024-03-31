using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Seedworks
{
    public interface IEfRepository<TEntity, TIdKey> 
        where TEntity : class
    {
        TEntity Find(TIdKey? key);

        TEntity Insert(TEntity entity);

        TEntity Update(TIdKey key, TEntity entity);

        void Delete(TIdKey key);

        IQueryable<TEntity> GetQueryableNoTracking();

        IQueryable<TEntity> GetQueryable();

        DbContext GetDbContext();

        void SaveChanges();
    }
}
