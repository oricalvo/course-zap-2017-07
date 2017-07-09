using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionInsideAspNetMvc.Services
{
    public interface IAuthService
    {
        bool IsLoggedIn();
    }

    public class AuthService : IAuthService
    {
        public bool IsLoggedIn()
        {
            return true;
        }
    }
}
