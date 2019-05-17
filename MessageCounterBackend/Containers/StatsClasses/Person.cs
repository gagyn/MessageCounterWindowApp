using MessageCounterBackend.JsonStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.Containers.Helpers_classes;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Person
    {
        public string FullName { get; }
        public double SentMessagesRatio { get; private set; }
        public double SentUniqueWordsRatio { get; private set; }
        public double SentAllWordsRatio { get; private set; }
        public double AvgNumberOfMessageInDaysWhenUserWroteAny { get; private set; }
        public double AvgNumberOfWordsInDaysWhenUserWroteAny { get; private set; }
        public DaysContainer DaysWhenUserWrittenSomething { get; private set; }
        public Day MostActiveDate { get; private set; }
        public MessagesContainer PersonMessages { get; }

        public Person(string fullName, MessagesContainer container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            this.FullName = fullName.DecodeString();
            PersonMessages = 
                new MessagesContainer(FindPersonMessages(container.Messages));

            SetDays();
            SetDoubleNumbers(container.NumberOfMessages, 
                container.NumberOfUniqueWords, container.NumberOfAllWords);
        }

        private List<Message> FindPersonMessages(List<Message> allMessages)
        {
            if (this.FullName == null)
                throw new ArgumentNullException(nameof(FullName));
            
            if (allMessages == null)
                throw new ArgumentNullException(nameof(allMessages));
            
            var messages = new List<Message>();

            foreach (var m in allMessages)
                if (this.FullName.Equals(m.sender_name.DecodeString()))
                    messages.Add(m);

            return messages;
        }

        private void SetDays()
        {
            if (PersonMessages?.Messages == null)
                throw new ArgumentNullException(nameof(PersonMessages));

            DaysWhenUserWrittenSomething = new DaysContainer(PersonMessages.Messages);
            MostActiveDate = DaysWhenUserWrittenSomething.DayWithMaxNumberOfMessages;
        }

        private void SetDoubleNumbers(int allMessagesCount, int uniqueWordsCount, int allWordsCount)
        {
            double ratioMesses, ratioWords, ratioAllWords, avgNumberMesses, avgNumberWords;

            ratioMesses = PersonMessages.NumberOfMessages 
                / (float)allMessagesCount * 100;

            avgNumberMesses = PersonMessages.NumberOfMessages
                / (float)DaysWhenUserWrittenSomething.Days.Count;

            ratioWords = PersonMessages.NumberOfUniqueWords
                / (float)uniqueWordsCount * 100;

            ratioAllWords = PersonMessages.NumberOfAllWords
                / (float)allWordsCount * 100;

            avgNumberWords = PersonMessages.NumberOfUniqueWords
                / (float)DaysWhenUserWrittenSomething.Days.Count;

            SentMessagesRatio = Math.Round(ratioMesses, 2);
            SentUniqueWordsRatio = Math.Round(ratioWords, 2);
            SentAllWordsRatio = Math.Round(ratioAllWords, 2);

            AvgNumberOfMessageInDaysWhenUserWroteAny = Math.Round(avgNumberMesses, 2);
            AvgNumberOfWordsInDaysWhenUserWroteAny   = Math.Round(avgNumberWords, 2);
        }
    }
}
