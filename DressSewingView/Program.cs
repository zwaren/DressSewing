using DressSewingServiceDAL.Interfaces;
using DressSewingServiceImplementDataBase;
using DressSewingServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace DressSewingView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
			var container = BuildUnityContainer();

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
			currentContainer.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IDesignerService, DesignerServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialService, MaterialServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDressService, DressServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IStoreService, StoreServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
