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
        public DaysContainer DaysWhenUserWrittenSomething { get; private set; }
        public Day MostActiveDate { get; private set; }
        public double AvgNumberOfMessageInDaysWhenUserWroteAny { get; private set; }
        public MessagesContainer PersonMessages { get; private set; }

        public Person(string fullName, List<Message> allMessages)
        {
            this.FullName = fullName.DecodeString();
            PersonMessages = 
                new MessagesContainer(FindPersonMessages(allMessages));

            SetDays();
            SetDoubleNumbers(allMessages.Count);
        }

        private List<Message> FindPersonMessages(List<Message> allMessages)
        {
            if (this.FullName == null)
            {
                throw new ArgumentNullException(nameof(FullName));
            }
            if (allMessages == null)
            {
                throw new ArgumentNullException(nameof(allMessages));
            }

            var messages = new List<Message>();

            foreach (var m in allMessages)
                if (this.FullName.Equals(m.sender_name.DecodeString()))
                    messages.Add(m);

            return messages;
        }

        private void SetDays()
        {
            if (PersonMessages?.Messages == null)
            {
                throw new ArgumentNullException(nameof(PersonMessages));
            }

            DaysWhenUserWrittenSomething = new DaysContainer(PersonMessages.Messages);
            MostActiveDate = DaysWhenUserWrittenSomething.DayWithMaxNumberOfMessages;
        }

        private void SetDoubleNumbers(int allMessagesCount)
        {
            double ratio, avgNumber;

            ratio = PersonMessages.NumberOfMessages 
                / (float)allMessagesCount * 100;

            avgNumber = PersonMessages.NumberOfMessages
                / (float)DaysWhenUserWrittenSomething.Days.Count;

            SentMessagesRatio = Math.Round(ratio, 2);
            AvgNumberOfMessageInDaysWhenUserWroteAny = Math.Round(avgNumber, 2);
        }
    }
}
