using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.DB.Model
{
    public class AdModel: DbModel
    {
        public AdType AdType { get; set; }

        public string Name { get; set; }

        public DateTime TimeCreate { get; set; }

        /// <summary>
        /// Id Владельца объявления
        /// </summary>
        public ObjectId OwnerAdId { get; set; }

        public string AdText { get; set; }
    }
}
