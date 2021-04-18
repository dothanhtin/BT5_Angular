using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public class RedisSharedConnection
    {

        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisSharedConnection()
        {
            ConfigurationOptions configurationOptions = new ConfigurationOptions()
            {
                ConnectTimeout = 1000,
                AbortOnConnectFail = false, // this prevents that error
                Password = AppSettings.Instance.RedisSettings.Password
            };
             configurationOptions.EndPoints.Add(AppSettings.Instance.RedisSettings.Hosts, AppSettings.Instance.RedisSettings.Port);

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
        /*private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            ConfigurationOptions conn = new ConfigurationOptions()
            {
                ConnectTimeout = 1000,
                AbortOnConnectFail = false // this prevents that error
            };
            conn.EndPoints.Add("10.70.123.2", 6379);
            conn.AllowAdmin = true;
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(conn);
            connectionMultiplexer.PreserveAsyncOrder = false;
            return connectionMultiplexer;
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }*/
    }
}
