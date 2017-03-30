using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using MongoDB.Driver;
using Ninject;
using Ninject.Modules;

namespace MyBooks.Web
{
    public class ControllerServiceLoadingModule : NinjectModule
    {
        public override void Load()
        {
            BindingControllers();
            BindInterfaceToService(Path.Combine(System.Web.HttpRuntime.BinDirectory, "MyBooks.Model.Core.dll"));
            BindInterfaceToService(Path.Combine(System.Web.HttpRuntime.BinDirectory, "MyBooks.Service.Core.dll"));
            BindingMongoDb();
        }

        private void BindingMongoDb()
        {
            Debug.Assert(Kernel != null, "Kernel != null");

            Kernel.Bind<MongoUrl>()
                .ToMethod(x => new MongoUrl(ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString))
                .InSingletonScope();

            Kernel.Bind<MongoClient>()
                .ToMethod(x => new MongoClient(Kernel.Get<MongoUrl>()))
                .InSingletonScope();

            Kernel.Bind<IMongoDatabase>()
                .ToMethod(x => Kernel.Get<MongoClient>().GetDatabase(Kernel.Get<MongoUrl>().DatabaseName))
                .InTransientScope();
        }

        private void BindInterfaceToService(string assemblyFile)
        {
            Debug.Assert(Kernel != null, "Kernel != null");
            var assembly = Assembly.LoadFrom(assemblyFile);
            var types = assembly.GetTypes();
            var interfaces = types.Where(x => !x.IsGenericType && x.IsInterface);
            foreach (var @interface in interfaces)
            {
                var impl = types
                    .Where(x => !x.IsInterface && !x.IsGenericType)
                    .First(x => x.Name.EndsWith(@interface.Name.Substring(1), StringComparison.CurrentCultureIgnoreCase));
                Kernel.Bind(@interface).To(impl).InTransientScope();
            }
        }

        private void BindingControllers()
        {
            Debug.Assert(Kernel != null, "Kernel != null");
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types.Where(x => x.FullName.EndsWith("Controller")))
            {
                Kernel.Bind(type).ToSelf().InThreadScope();
            }
        }
    }
}