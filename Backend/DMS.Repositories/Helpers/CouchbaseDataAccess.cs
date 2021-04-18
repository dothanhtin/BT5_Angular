using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.Core.Serialization;
using DMS.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Repositories
{
    public class CouchbaseDataAccess
    {
        private Cluster cluster;
        private CouchbaseDataAccess()
        {
            StartAsync();
        }

        public static CouchbaseDataAccess Instance { get; } = new CouchbaseDataAccess();

        private async void StartAsync()
        {
            var settings = AppSettings.Instance.CouchbaseSettings;

            var listServers = new List<Uri>();
            var listHosts = settings.Hosts.GetArray(";");

            foreach (var host in listHosts)
                listServers.Add(new Uri(host));

            var clientConfiguration = new ClientConfiguration { Servers = listServers};
            cluster = new Cluster(clientConfiguration);
            cluster.Configuration.Serializer = () =>
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    MaxDepth = 30,
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    DefaultValueHandling = DefaultValueHandling.Ignore,

                };

                return new DefaultSerializer(serializerSettings, serializerSettings);
            };
            var authenticator = new PasswordAuthenticator(settings.Username, settings.Password);
            cluster.Authenticate(authenticator);

            AccountBucket = await cluster.OpenBucketAsync("sohoa");
            ProfileBucket = await cluster.OpenBucketAsync("sohoa");
            DocumentBucket = await cluster.OpenBucketAsync("sohoa");
            AttachmentBucket = await cluster.OpenBucketAsync("sohoa");
            TokenBucket = await cluster.OpenBucketAsync("sohoa");
            StoreBucket = await cluster.OpenBucketAsync("sohoa");
            CategoryBucket = await cluster.OpenBucketAsync("sohoa");
            WorkspaceBucket = await cluster.OpenBucketAsync("sohoa");
            OrganizationBucket = await cluster.OpenBucketAsync("sohoa");
            CreateCodeBucket = await cluster.OpenBucketAsync("sohoa");
            ProfileTemplateBucket = await cluster.OpenBucketAsync("sohoa");
            DocumentTemplateBucket = await cluster.OpenBucketAsync("sohoa");
            MenuItemBucket = await cluster.OpenBucketAsync("sohoa");
            GroupBucket = await cluster.OpenBucketAsync("sohoa");
            DepartmentBucket = await cluster.OpenBucketAsync("sohoa");
            ParameterBucket = await cluster.OpenBucketAsync("sohoa");
            RegistrationFormBucket = await cluster.OpenBucketAsync("sohoa");
            Dictionary_DefinitionBucket = await cluster.OpenBucketAsync("sohoa");
            DictionaryBucket = await cluster.OpenBucketAsync("sohoa");
            DictionaryBucket = await cluster.OpenBucketAsync("sohoa");
            ProfileLogBucket = await cluster.OpenBucketAsync("sohoa");
            DanhMucTinhThanhPhoBucket = await cluster.OpenBucketAsync("sohoa");
            NotificationBucket = await cluster.OpenBucketAsync("sohoa");
            ReportDefinitionBucket = await cluster.OpenBucketAsync("sohoa");
            CommentBucket = await cluster.OpenBucketAsync("sohoa");
            RandomDataBucket = await cluster.OpenBucketAsync("sohoa");
            LoaiVanBanBucket = await cluster.OpenBucketAsync("sohoa");
            MyDriveBucket = await cluster.OpenBucketAsync("sohoa");
            MyFileBucket = await cluster.OpenBucketAsync("sohoa");
            InvalidProfileBucket = await cluster.OpenBucketAsync("sohoa");
            DataTrainBucket = await cluster.OpenBucketAsync("sohoa");
        }
        public IBucket InvalidProfileBucket { get; private set; }
        public IBucket DataTrainBucket { get; private set; }
        public IBucket RandomDataBucket { get; private set; }
        public IBucket MyDriveBucket { get; private set; }
        public IBucket MyFileBucket { get; private set; }
        public IBucket LoaiVanBanBucket { get; private set; }
        public IBucket ReportDefinitionBucket { get; private set; }
        public IBucket NotificationBucket { get; private set; }
        public IBucket DanhMucQuocGiaBucket { get; private set; }
        public IBucket DanhMucTinhThanhPhoBucket { get; private set; }
        public IBucket Dictionary_DefinitionBucket { get; private set; }
        public IBucket DictionaryBucket { get; private set; }
        public IBucket ProfileLogBucket { get; private set; }
        public IBucket AccountBucket { get; private set; }
        public IBucket ProfileBucket { get; private set; }
        public IBucket CommentBucket { get; private set; }
        public IBucket DocumentBucket { get; private set; }
        public IBucket AttachmentBucket { get; private set; }
        public IBucket TokenBucket { get; private set; }
        public IBucket StoreBucket { get; private set; }
        public IBucket CategoryBucket { get; private set; }
        public IBucket WorkspaceBucket { get; private set; }
        public IBucket OrganizationBucket { get; private set; }
        public IBucket CreateCodeBucket { get; private set; }
        public IBucket ProfileTemplateBucket { get; private set; }
        public IBucket DocumentTemplateBucket { get; private set; }
        public IBucket MenuItemBucket { get; private set; }
        public IBucket GroupBucket { get; private set; }
        public IBucket DepartmentBucket { get; private set; }
        public IBucket ParameterBucket { get; private set; }
        public IBucket RegistrationFormBucket { get; private set; }
    }
}
