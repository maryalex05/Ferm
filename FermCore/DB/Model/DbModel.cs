using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.DB.Model
{
    public class DbModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
