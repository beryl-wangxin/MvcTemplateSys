using MyMvc.IDAL;
using MyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.DAL
{
    public class RoleService:BaseService<Role>, IRoleService
    {
        public RoleService():base(new MyContext())
        {

        }
    }
}
