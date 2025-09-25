using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHHelper
{
    /// <summary>
    /// JSON������
    /// </summary>
    public class JSONHelper
    {
        /// <summary>
        /// ʹ��Newton��ʽʵ�����ת����JSON�ַ���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="x">����</param>
        /// <returns>�ַ���</returns>
        public static string EntityToJSON<T>(T x)
        {
            string result = string.Empty;

            try
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(x);
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;

        }

        /// <summary>
        /// ʹ��Newton��ʽJSON�ַ���ת����ʵ����
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="json">�ַ���</param>
        /// <returns>����</returns>
        public static T JSONToEntity<T>(string json)
        {
            T t = default(T);
            try
            {
                t = (T)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(T));
            }
            catch (Exception)
            {
                t = default(T);
            }

            return t;
        }
    }
}
