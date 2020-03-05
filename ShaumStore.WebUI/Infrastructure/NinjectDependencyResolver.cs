using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using ShaumStore.Domain.Abstract;
using ShaumStore.Domain.Entities;
using ShaumStore.Domain.Concrete;

namespace ShaumStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }
        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }
        private void AddBindings()
        {
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}