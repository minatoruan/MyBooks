using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MyBooks.Model.Core.Interfaces;
using MyBooks.Model.Entities;

namespace MyBooks.Model.Core
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly string _name;
        private readonly IMongoDatabase _mongodb;

        protected RepositoryBase(IMongoDatabase mongodb)
        {
            _name = typeof(T).Name;
            _mongodb = mongodb;
        }

        protected IMongoCollection<T> GetCollections()
        {
            return _mongodb.GetCollection<T>(_name);
        }

        protected async Task<bool> ExistsAsyn(Guid id)
        {
            return await GetCollections().Find(x => x.Id.Equals(id)).Limit(1).AnyAsync();
        }

        public void InsertOneAsync(T entity)
        {
            if (entity.Id.Equals(Guid.Empty) && ExistsAsyn(entity.Id).Result)
            {
                throw new ArgumentException($"InsertOneAsync-{_name}: Wrong argument.");
            }
            GetCollections().InsertOneAsync(entity);
        }

        public IList<T> GetList()
        {
            return GetCollections().Find(_ => true).ToList();
        }

        public T GetByIdAsyn(Guid id)
        {
            return GetCollections().Find(x => x.Id.Equals(id)).Limit(1).Single();
        }

        public bool Exists(Guid id)
        {
            return ExistsAsyn(id).Result;
        }
    }
}
