using System;
using MessageCounter.Services.StringDecoder;

namespace MessageCounter.Models
{
    public class Message
    {
        public string Content { get; }
        public DateTime DateTime { get; }
        public string AuthorName { get; }

        public Message(string content, DateTime dateTime, string authorName)
        {
            Content = content.DecodeString();
            DateTime = dateTime;
            AuthorName = authorName;
        }
    }
}
