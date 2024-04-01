using Clothes.Commons.Seedworks;
using Redis.OM;
using Redis.OM.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons
{
    public class RedisRepository<TDoc, TKey> : IRedisRepository<TDoc, TKey> where TDoc : class
    {
        private RedisConnectionProvider _provider;
        private RedisCollection<TDoc> _collection;
        
        public RedisRepository(RedisConnectionProvider provider)
        {
            _provider = provider;
            _collection = (RedisCollection<TDoc>) provider.RedisCollection<TDoc>();
        }

        public TDoc Add(TDoc doc)
        {
            _collection.Insert(doc);
            return doc;
        }

        public void DeleteById(string id)
        {
            _provider.Connection.Unlink($"Person:{id}");
        }

        public TDoc FindById(string key)
        {
            return _collection.FindById(key);
        }

        public RedisCollection<TDoc> GetCollection()
        {
            return _collection;
        }

        public TDoc Update(TDoc doc)
        {
            _collection.Update(doc);
            return doc;
        }
    }
}
