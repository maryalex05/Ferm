using FermCore.DB;
using FermCore.DB.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DBUser = FermCore.DB.Model.User;

namespace FermCore.Service.Mongo
{
    public class MongoService
    {
        private readonly DBMongo _dbMongo;

        public MongoService(DBMongo dbMongo)
        {
            _dbMongo = dbMongo;
        }

        public List<T> GetAll<T>(string collectionName)
        {
            var filter = new BsonDocument();
            var collection = _dbMongo.Database.GetCollection<T>(collectionName);
            var coll = collection.Find(filter).ToListAsync().Result;
            return coll;
        }

        public List<T> GetAll<T>(string collectionName, int limit = 20, int skip = 0)
        {
            var filter = new BsonDocument();
            var collection = _dbMongo.Database.GetCollection<T>(collectionName);
            var coll = collection.Find(filter)
                .Skip(skip)
                .Limit(limit).ToListAsync().Result;
            return coll;
        }

        // получаем один документ по id
        public T GetById<T>(string collectionName, ObjectId id)
        {
            var collection = _dbMongo.Database.GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument("_id", id)).First();
        }

        public void Insert<T>(string collectionName, T obj) where T : DbModel
        {
            var collection = _dbMongo.Database.GetCollection<T>(collectionName);
            collection.InsertOneAsync(obj);
        }

        public void Delete<T>(string collectionName, T obj) where T : DbModel
        {
            var collection = _dbMongo.Database.GetCollection<T>(collectionName);
            var filter = new BsonDocument("_id", obj.Id);
            collection.DeleteOne(filter);
        }

        public DBUser CreateUser(DBUser user, string collectionName)
        {
            if(user.Email == null || user.Password == null)
                throw new Exception();
            
            var collection = _dbMongo.Database.GetCollection<DBUser>(collectionName);
            var userId = ObjectId.GenerateNewId(DateTime.Now);
            DBUser us = user;
            us.Id = userId;
            collection.InsertOneAsync(us);

            return us;
        }

        public DBUser GetUserByEmail(string email,string collectionName)
        {
            var filter = new BsonDocument("Email", email);
            var collection = _dbMongo.Database.GetCollection<DBUser>(collectionName);
            var user = collection.Find<DBUser>(filter)?.FirstOrDefault();

            return user;
        }

        public DBUser GetUserValidate(string email, string password, string collectionName)
        {
            var filter = new BsonDocument("$and", new BsonArray {
                new BsonDocument("Password", password),
                new BsonDocument("Email", email)
            });
            var collection = _dbMongo.Database.GetCollection<DBUser>(collectionName);
            var user = collection.Find<DBUser>(filter).FirstOrDefault();

            return user;
        }
    }
}
