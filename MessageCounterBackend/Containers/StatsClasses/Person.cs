using MessageCounterBackend.JsonStructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Person
    {
        public string FullName { get; private set; }
        public int NumberOfMessages { get => Messages.Count; }
        public double SentMessagesRatio { get; private set; }
        public DaysContainer DaysWhenUserWrittenSomething { get; private set; }
        public Day MostActiveDate { get; private set; }
        public double AvgNumberOfMessageInDaysWhenUserWroteAny { get; private set; }
        public List<IGrouping<string, string>> SortedWordsByFrequents { get; private set; }

        private List<Message> Messages { get; set; }

        public Person(string fullName, List<Message> allMessages)
        {
            this.FullName = DecodeString(fullName);

            // all parameters are for safely
            SetMessages(fullName, allMessages);
            SetDays(this.Messages);
            SetDoubleNumbers(allMessages.Count, NumberOfMessages, DaysWhenUserWrittenSomething.Days.Count);
            SetFavoriteWord(this.Messages);
        }

        private void SetMessages(string fullName, List<Message> allMessages)
        {
            if (fullName == null)
            {
                throw new ArgumentNullException(nameof(fullName));
            }
            if (allMessages == null)
            {
                throw new ArgumentNullException(nameof(allMessages));
            }

            Messages = new List<Message>();

            foreach (var m in allMessages)
                if (fullName.Equals(DecodeString(m.sender_name)))
                    Messages.Add(m);
        }

        private void SetDays(List<Message> userMessages)
        {
            if (userMessages == null)
            {
                throw new ArgumentNullException(nameof(userMessages));
            }

            DaysWhenUserWrittenSomething = new DaysContainer(userMessages);
            MostActiveDate = DaysWhenUserWrittenSomething.DayWithMaxNumberOfMessages;
        }

        private void SetDoubleNumbers(int allMessagesCount, int numberOfUserMessages, int numberOfUserDays)
        {
            double ratio, avgNumber;
            ratio = numberOfUserMessages / (float)allMessagesCount * 100;
            avgNumber = numberOfUserMessages / (float)numberOfUserDays;

            SentMessagesRatio = Math.Round(ratio, 2);
            AvgNumberOfMessageInDaysWhenUserWroteAny = Math.Round(avgNumber, 2);
        }

        private void SetFavoriteWord(List<Message> userMessages)
        {
            var sortedWords =
                from message in (userMessages as IEnumerable<Message>)
                where message.content != null
                from word in message.content.Split()
                let decodedWord = DecodeString(word)
                where decodedWord.Length >= 3
                group decodedWord by decodedWord into groupedWords
                orderby groupedWords.Count()
                select groupedWords;

            SortedWordsByFrequents = sortedWords.Reverse().ToList();
        }

        private static string DecodeString(string text)
        {
            Encoding targetEncoding = Encoding.GetEncoding("ISO-8859-1");
            return Encoding.UTF8.GetString(targetEncoding.GetBytes(text));
        }
    }
}
