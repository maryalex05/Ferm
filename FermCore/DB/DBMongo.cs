using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.DB
{
    public class DBMongo
    {
        string db = "test";
        public IMongoDatabase Database { get; }
        public DBMongo(string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            Database = client.GetDatabase(db);
        }
    }
}
