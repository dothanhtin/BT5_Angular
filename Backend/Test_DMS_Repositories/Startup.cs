using DMS.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_DMS_Repositories
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
        }
    }
}
