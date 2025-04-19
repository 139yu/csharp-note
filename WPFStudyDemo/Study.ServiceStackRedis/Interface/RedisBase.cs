using System;
using ServiceStack.Redis;
using Study.ServiceStackRedis.Config;
using RedisConfig = Study.ServiceStackRedis.Config.RedisConfig;

namespace Study.ServiceStackRedis.Interface
{
    public class RedisBase:IDisposable
    {
        public IRedisClient iClient;

        public RedisBase()
        {
            iClient = RedisManager.GetRedisClient();
        }
        
        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            // 防止重复释放
            if (!_disposed)
            {
                if (disposing)
                {
                    iClient.Dispose();
                    iClient = null;
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            // 若对象已被正确释放，通知 GC 跳过终结器，提升性能。
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清除全部数据
        /// </summary>
        public virtual void FlushAll()
        {
            iClient.FlushAll();
        }
        /// <summary>
        /// 保存数据到硬盘，阻塞式
        /// </summary>
        public void Save()
        {
            iClient.Save();
        }
        /// <summary>
        /// 异步保存数据到硬盘
        /// </summary>
        public void SaveAsync()
        {
            iClient.SaveAsync();
        }
    }
}