using System.Text;
using System.Text.RegularExpressions;

namespace MessageCounter.Services.StringDecoder
{
    public static class StringDecoderService
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
