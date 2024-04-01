using Redis.OM.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Seedworks
{
    public interface IRedisRepository<TDoc, TKey>
    {
        RedisCollection<TDoc> GetCollection();

        TDoc Add(TDoc doc);

        TDoc FindById(string key);

        void DeleteById(string id);

        TDoc Update(TDoc doc);
    }
}
