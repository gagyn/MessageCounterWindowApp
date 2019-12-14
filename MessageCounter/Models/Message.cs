using System;
using System.Collections.Generic;
using MessageCounter.Services.StringDecoder;

namespace MessageCounter.Models
{
    public class Message
    {
        public string Content { get; }
        public DateTime DateTime { get; }
        public string AuthorName { get; }
        public IEnumerable<Word> Words { get; }

        public Message(string content, DateTime dateTime, string authorName, IEnumerable<Word> words)
        {
            Content = content.DecodeString();
            DateTime = dateTime;
            AuthorName = authorName;
            Words = words;
        }
    }
}
