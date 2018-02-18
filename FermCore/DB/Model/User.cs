using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.DB.Model
{
    public class User : DbModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
