using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows
{
    public class DependencyFactory
    {
        public static DependencyFactory Instance { get; } = new DependencyFactory();
        DependencyFactory()
        {
        }

        public IDependencyResolution DependencyResolution { get; set; }

    }
}
