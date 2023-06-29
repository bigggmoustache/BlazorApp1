using System.Collections.Generic;
using BlazorApp1.Server.Repository.Interfaces;
using MongoDB.Driver;


namespace BlazorApp1.Server.Repository
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public TEntity GetById(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(Builders<TEntity>.Filter.Empty).ToEnumerable();
        }

        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);

        }

        public void Remove(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", (entity as dynamic)._id);
            _collection.DeleteOne(filter);
        }
    }
}