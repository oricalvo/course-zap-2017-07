using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(CookieBasedAuthentication.App_Start.OwinStartup))]

namespace CookieBasedAuthentication.App_Start
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                return next();
            });

            var options = new CookieAuthenticationOptions()
            {
                CookieName = "XXX",
            };
            app.UseCookieAuthentication(options);
        }
    }
}
