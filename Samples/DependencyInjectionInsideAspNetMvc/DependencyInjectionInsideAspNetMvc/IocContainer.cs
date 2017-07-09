using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DependencyInjectionInsideAspNetMvc.Controllers;
using DependencyInjectionInsideAspNetMvc.Services;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.MicroKernel.SubSystems.Configuration;

namespace DependencyInjectionInsideAspNetMvc
{
    internal class IocContainer
    {
        public static WindsorContainer instance;

        public static void Setup()
        {
            instance = new WindsorContainer();

            instance.Register(Component.For<IAuthService>().ImplementedBy<AuthService>());
            //instance.Register(Component.For<HomeController>().ImplementedBy<HomeController>());

            instance.Install(FromAssembly.This());

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactoryOnWindsor(instance));
        }
    }

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Where(Component.IsInSameNamespaceAs<HomeController>()).WithService.Self().LifestyleTransient());
        }
    }

    class ControllerFactoryOnWindsor : DefaultControllerFactory
    {
        private WindsorContainer container;

        public ControllerFactoryOnWindsor(WindsorContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)this.container.Resolve(controllerType);
            //return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}

public class ControllersInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Classes.FromThisAssembly()
            .Where(Component.IsInSameNamespaceAs<HomeController>())
            .WithService
            .Self()
            .Li());
    }
}
