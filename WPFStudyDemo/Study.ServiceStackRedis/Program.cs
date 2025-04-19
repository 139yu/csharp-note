using System;
using Study.ServiceStackRedis.Config;

namespace Study.ServiceStackRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisClient = RedisManager.GetRedisClient();
            redisClient.Set("test", "test");
        }
    }
}