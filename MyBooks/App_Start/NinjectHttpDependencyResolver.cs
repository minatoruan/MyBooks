using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace MyBooks.Web
{
    public class NinjectHttpDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectHttpDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Dispose()
        {

        }

        /*public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                var controllerType = base.GetControllerType(requestContext, controllerName);
                return _kernel.Get(controllerType) as IController;
            }
            catch (Exception)
            {
                return base.CreateController(requestContext, controllerName);
            }
        }*/

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}