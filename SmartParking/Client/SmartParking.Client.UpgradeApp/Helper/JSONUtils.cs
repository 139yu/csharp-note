using System.Text.Json;

namespace SmartParking.Client.UpgradeApp.Helper
{
    public static class JSONUtils
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            // 采用驼峰写法，首字母小写
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            // 该属性设置为 true 时，在 JSON 反序列化过程中，System.Text.Json 会忽略 JSON 字段名称与 C# 对象属性名称之间的大小写差异。
            // 这意味着 JSON 中的字段名无论是大写、小写还是混合大小写，只要名称匹配（不考虑大小写），都能正确映射到对应的 C# 对象属性。
            PropertyNameCaseInsensitive = true,
        };

        public static string ToJsonString<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, _options);
        }

        public static T ToObject<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _options);
        }
    }
}