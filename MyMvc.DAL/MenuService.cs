using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyMvc.IDAL;
using MyMvc.Models;

namespace MyMvc.DAL
{
    public class MenuService : IMenuService
    {
        private readonly MyContext _db = new MyContext();

        IQueryable<Models.Menu> IMenuService.GetAll()
        {
            return _db.Set<Models.Menu>().AsNoTracking();
        }
    }
}
