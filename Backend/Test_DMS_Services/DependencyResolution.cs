using DMS.Core.Repositories;
using DMS.Core.Services;
using DMS.Repositories;
using DMS.Services;
using DMS.Workflows;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using VNPT.Framework.Cache;
using VNPT.Framework.Cache.Memory;
using VNPT.Framework.Logger;
using VNPT.Framework.Logger.File;

namespace Test_DMS_Workflow
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
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<IProfileService, ProfileService>();
            container.RegisterType<IOrganizationRepository, OrganizationRepository>();
            container.RegisterType<IOrganizationService, OrganizationService>();
            container.RegisterType<IDocumentRepository, DocumentRepository>();
            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterType<ITokenRepository, TokenRepository>();
            container.RegisterType<ITokenService, TokenService>();
            container.RegisterType<IAttachmentRepository, AttachmentRepository>();
            container.RegisterType<IAttachmentService, AttachmentService>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IStoreRepository, StoreRepository>();
            container.RegisterType<IStoreService, StoreService>();
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
