using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Study.StackExchangeRedis.Service
{
    public class RedisService
    {
        private readonly IDatabase db;

        public RedisService()
        {
            db = ConnectionMultiplexer.Connect("localhost").GetDatabase();
        }

        public string GetString(string key)
        {
            return db.StringGet(key);
        }

        public bool SetString(string key, string value, TimeSpan? expiry = null)
        {
            return db.StringSet(key, value, expiry);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await db.StringGetAsync(key);
        }

        public async Task<bool> SetStringAsync(string key, string value, TimeSpan? expiry = null)
        {
            return await db.StringSetAsync(key, value, expiry);
        }
    }
}