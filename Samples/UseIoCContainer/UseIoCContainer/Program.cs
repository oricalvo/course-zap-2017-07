using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseIoCContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            WindsorContainer container = new WindsorContainer();

            container.Register(Component.For<IBL>().ImplementedBy<MockBL>().LifestyleTransient());
            container.Register(Component.For<IUI>().ImplementedBy<UI>().LifestyleTransient());

            //var ui = new UI(new MockBL());

            TestResolvePerf(container);
            TestManualPerf();

            TestResolvePerf(container);
            TestManualPerf();
        }

        static void TestManualPerf()
        {
            DateTime begin = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                new UI(new MockBL());
            }
            DateTime end = DateTime.Now;

            TimeSpan time = end - begin;
            Console.WriteLine(time.TotalMilliseconds);
        }

        static void TestResolvePerf(WindsorContainer container)
        {
            DateTime begin = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                container.Resolve<IUI>();
            }
            DateTime end = DateTime.Now;

            TimeSpan time = end - begin;
            Console.WriteLine(time.TotalMilliseconds);
        }
    }



    class UI : IUI
    {
        private IBL bl;

        public UI(IBL bl)
        {
            this.bl = bl;
        }

        public void Save()
        {
            this.bl.Save();
        }
    }

    class MockBL : IBL
    {
        public MockBL()
        {
        }

        public void Save()
        {
            Console.WriteLine("MockBL");
        }
    }

    class ProductionBL : IBL
    {
        public void Save()
        {
            Console.WriteLine("ProductionBL");
        }
    }

    interface IUI
    {
        void Save();
    }

    interface IBL
    {
        void Save();
    }
}
