using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcWithIoC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IBL bl)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }

    public interface IBL
    {
        void Save();
    }
}