using FermCore.DB.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.Service.AD
{
    public interface IADReadService
    {
        IEnumerable<AdModel> GetAll();

        AdModel GetById(ObjectId id);

    }
}
