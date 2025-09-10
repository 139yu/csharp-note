using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Common
{
    public static class ActionManager
    {
        private static readonly Dictionary<string, Delegate> ActionDictionary = new Dictionary<string, Delegate>();

        public static void UnRegister(string key)
        {
            if (ActionDictionary.ContainsKey(key))
            {
                ActionDictionary.Remove(key);
            }
        }
        public static void Register<T>(string key, Action<T> d)
        {
            ActionDictionary.TryAdd(key, d);
        }
        public static void Register(string key, Action d)
        {
            ActionDictionary.TryAdd(key, d);
        }
        public static void Register<T, R>(string key, Func<T, R> d)
        {
            ActionDictionary.TryAdd(key, d);
        }
        public static void Register<R>(string key, Func< R> d)
        {
            ActionDictionary.TryAdd(key, d);
        }
        public static void Execute(string key)
        {
            if (ActionDictionary.TryGetValue(key, out var value))
            {
                value.DynamicInvoke();
            }
        }

        public static R ExecuteAndResult<T, R>(string key, T data)
        {
            if (ActionDictionary.TryGetValue(key, out var value))
            {
                if (value is Func<T, R> action) return action.Invoke(data);
            }

            throw new Exception("key is not exists");
        }
        public static R ExecuteAndResult<R>(string key)
        {
            if (ActionDictionary.TryGetValue(key, out var value))
            {
                if (value is Func<R> action) return action.Invoke();
            }

            throw new Exception("key is not exists");
        }
    }
}