using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvc.IBLL;
using MyMvc.BLL;
using MyMvc.Models;


namespace MyMvc.MvcSite.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //登录
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //登录
        [HttpPost]
        public ActionResult Login(string userId, string password, string checkcode, string returnUrl)
        {
            userId = userId.Trim();
            password = password.Trim();
            //校验用户名
            if (string.IsNullOrEmpty(userId))
            {
                return ErrorResult("请输入用户名");
            }
            //校验密码
            if (string.IsNullOrEmpty(password))
            {
                return ErrorResult("请输入密码");
            }
            //根据userID获取用户信息

            IUserManager userManager = new UserManager();
            var user=userManager.GetUserByName(userId);
            if (user != null)
            {
                if (!user.IsEffective) return ErrorResult("用户名已失效，请联系管理员！");
                if (user.Password == password)
                {
                    //登录信息加密
                    var loginUser = $"{userId},{password},{DateTime.Now.AddMinutes(10)},{user.RealName}";

                    //加密信息保存cookie

                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = "/";
                    }
                    return new RedirectResult(returnUrl);
                }
                else
                {
                    return ErrorResult("密码有误！");
                }
            }
            else
            {
                return ErrorResult("用户名有误！");
            }

           
        }
    }
}