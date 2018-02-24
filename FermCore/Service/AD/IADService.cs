using FermCore.DB.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.Service.AD
{
    public interface IADService
    {
        IEnumerable<AdModel> GetAll();

        IEnumerable<AdModel> GetAll(string collectionName, int limit = 20, int skip = 0);

        AdModel GetById(ObjectId id);

        /// <summary>
        /// Получить все типы обьявлений
        /// </summary>
        /// <returns></returns>
        IEnumerable<AdType> GetAllAdType();

        void Insert(AdModel ad, ObjectId ownerAdId);

        void InsertAdType(AdType adType);

        void Delete(ObjectId id);

    }
}
