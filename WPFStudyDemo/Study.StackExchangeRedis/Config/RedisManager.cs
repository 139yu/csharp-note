using System;
using StackExchange.Redis;

namespace Study.StackExchangeRedis.Config
{
    public class RedisManager
    {
        private static RedisConfig config = new RedisConfig();
        private static readonly Lazy<ConnectionMultiplexer> LzayCOnnection;

        static RedisManager()
        {
            LzayCOnnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(new ConfigurationOptions()
                {
                    EndPoints = {config.endPoint},
                    ConnectTimeout = config.connectTimeout,
                    SyncTimeout = config.connectTimeout,
                    AsyncTimeout = config.connectTimeout,
                    AbortOnConnectFail = config.abortOnConnectFail,
                    KeepAlive = config.keepAlive,
                });
            });
        }

        public static ConnectionMultiplexer GetConnection()
        {
            return LzayCOnnection.Value;
        }
    }
}