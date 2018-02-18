using FermCore.DB;
using FermCore.Service.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DBUser = FermCore.DB.Model.User;

namespace FermCore.Service.User
{
    public class UserService : IUserService
    {
        private readonly DBMongo _dbMongo;
        private readonly MongoService _mongoService;
        private string colName = "User";

        public UserService(
            DBMongo dbMongo,
            MongoService mongoService)
        {
            _dbMongo = dbMongo;
            _mongoService = mongoService;
        }

        public DBUser GetByEmail(string email)
        {
            return _mongoService.GetUserByEmail(email, colName);
        }

        public DBUser Create(DBUser user)
        {
            return _mongoService.CreateUser(user, colName);
        }

        public DBUser Validate(string email, string password)
        {
            return _mongoService.GetUserValidate(email, password, colName);
        }
    }
}
