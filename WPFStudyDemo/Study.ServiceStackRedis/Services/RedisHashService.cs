﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.ServiceStackRedis.Interface;

namespace Study.ServiceStackRedis.Services
{
    /// <summary>
    /// Hash:类似dictionary，通过索引快速定位到指定元素的，耗时均等，跟string的区别在于不用反序列化，直接修改某个字段
    /// string的话要么是 001:序列化整个实体
    ///           要么是 001_name:  001_pwd: 多个key-value
    /// Hash的话，一个hashid-{key:value;key:value;key:value;}
    /// 可以一次性查找实体，也可以单个，还可以单个修改
    /// </summary>
    public class RedisHashService : RedisBase
    {
        #region 添加
        /// <summary>
        /// 向hashid集合中添加key/value
        /// </summary>       
        public bool SetEntryInHash(string hashid, string key, string value)
        {
            return iClient.SetEntryInHash(hashid, key, value);
        }
        /// <summary>
        /// 如果hashid集合中存在key/value则不添加返回false，
        /// 如果不存在在添加key/value,返回true
        /// </summary>
        public bool SetEntryInHashIfNotExists(string hashid, string key, string value)
        {
            return iClient.SetEntryInHashIfNotExists(hashid, key, value);
        }
        /// <summary>
        /// 存储对象T t到hash集合中
        /// 需要包含Id，然后用Id获取
        /// </summary>
        public void StoreAsHash<T>(T t)
        {
            iClient.StoreAsHash<T>(t);
        }
        #endregion

        #region 获取
        /// <summary>
        /// 获取对象T中ID为id的数据。
        /// </summary>
        public T GetFromHash<T>(object id)
        {
            return iClient.GetFromHash<T>(id);
        }
        /// <summary>
        /// 获取所有hashid数据集的key/value数据集合
        /// </summary>
        public Dictionary<string, string> GetAllEntriesFromHash(string hashid)
        {
            return iClient.GetAllEntriesFromHash(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中的数据总数
        /// </summary>
        public long GetHashCount(string hashid)
        {
            return iClient.GetHashCount(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中所有key的集合
        /// </summary>
        public List<string> GetHashKeys(string hashid)
        {
            return iClient.GetHashKeys(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中的所有value集合
        /// </summary>
        public List<string> GetHashValues(string hashid)
        {
            return iClient.GetHashValues(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中，key的value数据
        /// </summary>
        public string GetValueFromHash(string hashid, string key)
        {
            return iClient.GetValueFromHash(hashid, key);
        }
        /// <summary>
        /// 获取hashid数据集中，多个keys的value集合
        /// </summary>
        public List<string> GetValuesFromHash(string hashid, string[] keys)
        {
            return iClient.GetValuesFromHash(hashid, keys);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除hashid数据集中的key数据
        /// </summary>
        public bool RemoveEntryFromHash(string hashid, string key)
        {
            return iClient.RemoveEntryFromHash(hashid, key);
        }
        #endregion

        #region 其它
        /// <summary>
        /// 判断hashid数据集中是否存在key的数据
        /// </summary>
        public bool HashContainsEntry(string hashid, string key)
        {
            return iClient.HashContainsEntry(hashid, key);
        }
        /// <summary>
        /// 给hashid数据集key的value加countby，返回相加后的数据
        /// </summary>
        public double IncrementValueInHash(string hashid, string key, double countBy)
        {
            return iClient.IncrementValueInHash(hashid, key, countBy);
        }
        #endregion
    }
}
