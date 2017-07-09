using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedComponent
{
    class Program
    {
        static void Main(string[] args)
        {
WindsorContainer container = new WindsorContainer();

container.Register(Component.For<IMyService>().ImplementedBy<MyService1>());
container.Register(Component.For<IMyService>().ImplementedBy<MyService2>().Named("Service2").IsDefault());
container.Register(Component.For<IMyService>().ImplementedBy<MyService3>().IsDefault());

            Console.WriteLine(container.Resolve<IMyService>("Service2").GetType().Name);
        }
    }

    interface IMyService
    {
    }

    class MyService1 : IMyService
    {
    }

    class MyService2 : IMyService
    {
    }

    class MyService3 : IMyService
    {
    }
}
