using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(bool? dummy)
        {
            return Redirect("http://localhost:65423/authorize?client_id=client1&response_type=code");
        }
    }
}