using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvc.IBLL;
using MyMvc.IDAL;
using MyMvc.DAL;
using MyMvc.Models;
using MyMvc.Utility;
//业务逻辑层
namespace MyMvc.BLL
{
    public class UserManager : IUserManager
    {
        public void CreateUser(string name, string password)
        {
            using(IUserService userSvc=new UserService())
            {
                userSvc.CreateAsync(new User()
                {
                    Name=name,
                    Password= MD5Encryption.Md5(password),
                    RealName="超级管理员",
                    Sex=Gender.Woman,
                    Phone="17629780070"
                });
            }
        }

        public User GetUserByName(string name)
        {
            using(IUserService userSvc=new UserService())
            {
                var user = userSvc.GetAll(m => m.Name == name).FirstOrDefault();
                return user;
            }
        }

    }
}
