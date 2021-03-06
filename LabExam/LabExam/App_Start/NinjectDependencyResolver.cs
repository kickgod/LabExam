﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabExam.IServices;
using LabExam.Services;


namespace LabExam.App_Start
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserAccountService>().To<UserAccountService>().InTransientScope(); //配置接口
            kernel.Bind<IEncryptionDataService>().To<EncryptionDataService>().InTransientScope(); //配置接口
            kernel.Bind<IUserSuggestionService>().To<UserSuggestionService>().InTransientScope();
        }
    }
}