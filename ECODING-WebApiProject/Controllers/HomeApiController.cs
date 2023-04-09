using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECODING_WebApiProject.Controllers
{
    public class HomeApiController : Controller
    {
        // GET: HomeApi
        public ActionResult Index()
        {
            return View();
        }
    }
}