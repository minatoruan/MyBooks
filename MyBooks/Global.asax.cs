using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;

namespace MyBooks.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        // ReSharper disable once InconsistentNaming
        private static readonly IKernel _kernel = new StandardKernel();

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            _kernel.Load(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new NinjectHttpDependencyResolver(_kernel));
            //ControllerBuilder.Current.SetControllerFactory(new NinjectHttpDependencyResolver(_kernel));
            return _kernel;
        }
    }
}
