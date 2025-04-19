using StackExchange.Redis;

namespace Study.StackExchangeRedis.Config
{
    public class RedisConfig
    {
        public string endPoint = "127.0.0.1:6379";
        // 单位毫秒
        public int connectTimeout = 5000;
        // 同步操作超时时间
        public int SyncTimeout = 1000;
        // 异步操作超时时间
        public int AsyncTimeout = 1000;
        // 连接失败时重试而非抛出异常
        public bool abortOnConnectFail = false;
        // 保持连接活跃
        public int keepAlive = 180;
    }
}