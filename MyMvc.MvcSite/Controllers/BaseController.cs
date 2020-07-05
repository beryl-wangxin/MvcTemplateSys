using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvc.MvcSite.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        public JsonResult JsonResult(string msg,Object obj)
        {
            return Json(new { result = true, message = msg, obj });
        }
        public JsonResult ErrorResult(string msg,Object obj=null)
        {
            return Json(new { result = false, message = msg, obj });
        }
    }
}