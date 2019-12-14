using System;

namespace MessageCounter.Models
{
    static class MessageFactory
    {
        public static Message Create(string content, ulong timeStamp, string authorName)
        {
            var sentAt = new DateTime().AddMilliseconds(timeStamp);
            return new Message(content, sentAt, authorName);
        }
    }
}