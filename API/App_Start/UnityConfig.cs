using BusinessLogic.Application;
using BusinessLogic.Application.Interface;
using Common.Persistence;
using Common.Persistence.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeApplication, EmployeeApplication>();
            container.RegisterType<IEmployeePersistence, EmployeePersistence>();

            container.RegisterType<IOvertimeApplication, OvertimeApplication>();
            container.RegisterType<IOvertimePersistence, OvertimePersistence>();

            container.RegisterType<IOvertimeFileApplication, OvertimeFileApplication>();
            container.RegisterType<IOvertimeFilePersistence, OvertimeFilePersistence>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}