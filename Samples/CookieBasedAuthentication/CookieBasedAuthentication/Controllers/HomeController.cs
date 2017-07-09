using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CookieBasedAuthentication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorize()
        {
            var authentication = HttpContext.GetOwinContext().Authentication;

            authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false },
                new ClaimsIdentity(new[] { new Claim(ClaimsIdentity.DefaultNameClaimType, "Ori") }, "Cookies"));

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult SecuredAction()
        {
            string xsrf = HttpContext.Request.Form["XXX"];
            string cookie = HttpContext.Request.Cookies["XXX"].Value;

            return Content("Hello");
        }
    }
}