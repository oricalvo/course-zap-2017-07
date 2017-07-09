using DependencyInjectionInsideAspNetMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependencyInjectionInsideAspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IAuthService service)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}