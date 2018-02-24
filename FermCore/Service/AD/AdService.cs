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
    public class AdService : IADService
    {
        private readonly DBMongo _dbMongo;
        private readonly MongoService _mongoService;

        private string colName = "ad";
        private string AdTypeCol = "AdType";

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

        public IEnumerable<AdModel> GetAll(string collectionName, int limit = 20, int skip = 0)
        {
            return _mongoService.GetAll<AdModel>(collectionName, limit, skip);
        }

        public AdModel GetById(ObjectId id)
        {
            return _mongoService.GetById<AdModel>(colName, id);
        }

        public IEnumerable<AdType> GetAllAdType()
        {
            return _mongoService.GetAll<AdType>(AdTypeCol);
        }

        public void Insert(AdModel ad, ObjectId ownerAdId, ObjectId adType)
        {
            ad.OwnerAdId = ownerAdId;
            ad.TimeCreate = DateTime.Now;
            ad.AdTypeId = adType;

            _mongoService.Insert(colName, ad);
        }

        public void Delete(ObjectId id)
        {
            var ad = GetById(id);
            if (ad != null)
                _mongoService.Delete(colName, ad);
        }

    }
}
