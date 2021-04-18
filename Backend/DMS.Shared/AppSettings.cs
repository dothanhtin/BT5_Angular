using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public class AppSettings
    {
        public static AppSettings Instance { get; } = new AppSettings();
        private AppSettings()
        {
            
        }
        
        public CouchbaseSettings CouchbaseSettings { get; set; }
        public ElasticSetting ElasticSettings { get; set; }
        public PermissionSetting PermissionSettings { get; set; }
        public FTPServer FtpServers { get; set; }
        public OcrSetting OcrSettings { get; set; }
        public AmazonS3Setting AmazonS3Settings { get; set; }
        public RedisSetting RedisSettings { get; set; }
        public ElasticLoggerSettings ElasticLoggerSettings { get; set; }
        public ItSelfSetting ItSelfSettings { get; set; }
    }
}
