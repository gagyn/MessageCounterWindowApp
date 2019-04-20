using MessageCounterBackend.JsonStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Person
    {
        public string FullName { get; private set; }
        public int NumberOfMessages { get => Messages.Count; }
        public float SentMessagesRatio { get; private set; }
        public DaysContainer DaysWhenUserWrittenSomething { get; private set; }
        /// <summary>
        /// MostActiveDate can be NULL if the person didn't send any text at all!
        /// </summary>
        public DateTime MostActiveDate { get; private set; }

        private List<Message> Messages { get; set; }

        public Person(string fullName, List<Message> allMessages)
        {
            this.FullName = DecodeString(fullName);
            Messages = new List<Message>();

            foreach (var m in allMessages)
                if (fullName.Equals(DecodeString(m.sender_name)))
                    Messages.Add(m);

            SentMessagesRatio = NumberOfMessages / allMessages.Count * 100;
            DaysWhenUserWrittenSomething = new DaysContainer(Messages);
            MostActiveDate = DaysWhenUserWrittenSomething.DayWithMaxNumberOfMessages.thisDateTime;
        }

        private static string DecodeString(string text)
        {
            Encoding targetEncoding = Encoding.GetEncoding("ISO-8859-1");
            var unescapeText = System.Text.RegularExpressions.Regex.Unescape(text);
            return Encoding.UTF8.GetString(targetEncoding.GetBytes(unescapeText));
        }
    }
}
