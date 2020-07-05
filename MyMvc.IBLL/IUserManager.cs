using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvc.Models;
//业务逻辑层接口
namespace MyMvc.IBLL
{
    public interface IUserManager
    {
        //注册

        //登录
        User GetUserByName(string name);

        //修改密码

        //创建用户
        void CreateUser(string name, string password);
    }
}
