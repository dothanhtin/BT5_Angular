using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace DMS.Workflows
{
    public interface IDependencyResolution
    {
        void RegisterTypes(IUnityContainer container);
        T Resolve<T>();
    }
}
