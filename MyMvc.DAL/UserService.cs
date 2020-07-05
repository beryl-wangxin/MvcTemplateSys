using MyMvc.IDAL;
using MyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.DAL
{
    public class UserService:BaseService<User>, IUserService
    {
        public UserService() : base(new MyContext()) { }

    }
}
