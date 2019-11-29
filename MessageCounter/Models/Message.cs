using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageCounter.Services.StringDecoder;
using MessageCounter.Services.WordsGrouper;

namespace MessageCounter.Models
{
    public class Message
    {
        public string Content { get; }
        public DateTime DateTime { get; }
        public Person Author { get; }
        public IEnumerable<IGrouping<string, string>> Words { get; }

        public Message(string content, DateTime dateTime, Person author)
        {
            Content = content.DecodeString();
            DateTime = dateTime;
            Author = author;
            var wordsGrouper = new WordsGrouper(this);
            Words = wordsGrouper.GroupWords();
        }
    }
}
