using DMS.Shared;
using DMS.Workflows;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_DMS_Workflow
{
    public class Startup
    {
        public static void Start()
        {
            var couchbaseSettings = new CouchbaseSettings
            {
                Hosts = "http://222.255.102.166:8091",
                Password = "Dev@2019",
                Username = "dev"
            };
            
            AppSettings.Instance.CouchbaseSettings = couchbaseSettings;
            DependencyResolution.Instance.Start();
            DependencyFactory.Instance.DependencyResolution = DependencyResolution.Instance;
        }
    }
}
