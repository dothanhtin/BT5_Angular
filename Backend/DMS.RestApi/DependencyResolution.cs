using DMS.Core.Repositories;
using DMS.Core.Services;
using DMS.Repositories;
using DMS.Services;
using DMS.Shared;
using DMS.Workflows;

using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using VNPT.Framework.Cache;
using VNPT.Framework.Cache.Memory;
using VNPT.Framework.Logger;
using VNPT.Framework.Logger.File;

namespace DMS.RestApi
{
    public sealed class DependencyResolution: IDependencyResolution
    {
        static DependencyResolution()
        {
            Container = new UnityContainer();
        }

        public void Start()
        {
            RegisterTypes(Container);
         
        }

        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICache, MemoryCache>();
            container.RegisterType<ILogger, FileLogger>();


            container.RegisterType<IDanhMucTinhThanhPhoService, DanhMucTinhThanhPhoService>();
            container.RegisterType<IDanhMucTinhThanhPhoRepository, DanhMucTinhThanhPhoRepository>();

            container.RegisterType<IModelService, ModelService>();
            container.RegisterType<IModelRepository, ModelRepository>();

            container.RegisterType<ITokenRepository, TokenRepository>();
            container.RegisterType<ITokenService, TokenService>();
        }
        
        public void Dispose()
        {
            Container.Dispose();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static IUnityContainer Container { get; private set; }
        public static DependencyResolution Instance { get; } = new DependencyResolution();
    }
}
