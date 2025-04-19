using ServiceStack.Redis;

namespace Study.ServiceStackRedis.Config
{
    public class RedisManager
    {
        private static RedisConfig redisConfig = new RedisConfig();
        private static PooledRedisClientManager prcManager;

        static RedisManager()
        {
            CreateManager();
        }

        private static void CreateManager()
        {
            string[]  writeHosts = redisConfig.WriteServerList.Split(",");
            string[] readHosts = redisConfig.ReadServerList.Split(",");
            prcManager = new PooledRedisClientManager(writeHosts, readHosts,new RedisClientManagerConfig()
            {
                MaxReadPoolSize = redisConfig.MaxReadPoolSize,
                MaxWritePoolSize = redisConfig.MaxWritePoolSize,
                AutoStart = redisConfig.AutoStart,
            });
            
        }

        public static IRedisClient GetRedisClient()
        {
            return prcManager.GetClient();
        }
    }
}