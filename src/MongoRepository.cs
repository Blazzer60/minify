using System.Collections.Generic;
using Minify.Interfaces;
using Minify.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Minify{
    public class MongoRepository : IRepository
    {
        private IMongoDatabase database;
        private IMongoCollection<MinifyData> collection;
        public MongoRepository(){
            var client = new MongoClient(
                "mongodb+srv://EpsiEleve:TvxreYSXYCg89lz1@cluster0-b8srw.azure.mongodb.net/test?retryWrites=true&w=majority"
            );
            database = client.GetDatabase("Epsi");
            collection = database.GetCollection<MinifyData>("QuentinHalouin");
        }
        public void Add(MinifyData minifyData)
        {
            collection.InsertOne(minifyData);
        }

        public void Delete(string key)
        {
            var filtre = Builders<MinifyData>.Filter.Eq("Key", key);
            collection.DeleteOne(filtre);
        }

        public IEnumerable<MinifyData> Get()
        {
            var data = collection.Find(new BsonDocument()).ToList();
            return data;
        }

        public MinifyData Get(string key)
        {
            var filtre = Builders<MinifyData>.Filter.Eq("Key", key);
            return collection.Find(filtre).First();
        }
    }
}