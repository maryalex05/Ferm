using FermCore.DB;
using FermCore.DB.Model;
using FermCore.Service.Mongo;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.Service.AD
{
    public class AdService : IADReadService
    {
        private readonly DBMongo _dbMongo;
        private readonly MongoService _mongoService;
        private string colName = "ad";

        public AdService(DBMongo dbMongo,
            MongoService mongoService)
        {
            _dbMongo = dbMongo;
            _mongoService = mongoService;
        }

        public IEnumerable<AdModel> GetAll()
        {
            return _mongoService.GetAll<AdModel>(colName);
        }

        public AdModel GetById(ObjectId id)
        {
            return _mongoService.GetById<AdModel>(colName, id);
        }

        public void Insert(AdModel ad)
        {
            _mongoService.Insert(colName, ad);
        }

    }
}
