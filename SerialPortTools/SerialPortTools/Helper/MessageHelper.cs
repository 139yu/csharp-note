using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortTools.Helper
{
    public static class MessageHelper
    {
        public static bool showLogFormat = false;
        public static bool showASCII = true;
        public static string FormatMessage(this string msg)
        {

            StringBuilder sb = new StringBuilder();
            if (showLogFormat)
            {
                sb.AppendLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]");
            }
            sb.AppendLine(msg);
            return sb.ToString();
        }
    }
}
