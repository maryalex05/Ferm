using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBUser = FermCore.DB.Model.User;
namespace FermCore.Service.User
{
    public interface IUserService
    {
        DBUser GetByEmail(string email);

        DBUser Create(DBUser user);

        DBUser Validate(string email, string password);
    }
}
