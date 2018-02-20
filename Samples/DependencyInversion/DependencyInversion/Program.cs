using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDI();

            var ui = new UI(new ProductionBL(new MockDAL(new ));
            ui.Save();
        }

        static void SetupDI()
        {
            ServiceLocator.Regsiter(typeof(IBL), typeof(MockBL)); ;
        }
    }

    class UI
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

    interface IBL
    {
        void Save();
    }

    class MockBL : IBL
    {
        void Save()
        {
        }
    }

    class ServiceLocator
    {
        private Dictionary<Type, Type> entries;


    }

}
