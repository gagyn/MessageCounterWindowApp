﻿using System.Text;
using System.Text.RegularExpressions;

namespace MessageCounterBackend.Containers.Helpers_classes
{
    public static class StringDecoder
    {
        public static string DecodeString(this string text)
        {
            Encoding targetEncoding = Encoding.GetEncoding("ISO-8859-1");
            try
            {
                var s = Regex.Unescape(text);
                return Encoding.UTF8.GetString(targetEncoding.GetBytes(s));
            }
            catch
            {
                return text;
            }
        }
    }
}
