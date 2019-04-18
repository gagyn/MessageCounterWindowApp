using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Day
    {
        public DateTime thisDateTime;
        public int NumberOfMessages { get => messages.Count; }

        private readonly List<Message> messages;

        public Day() => messages = new List<Message>();
        public Day(List<Message> messages, ref int currentIndex)
        {
            this.thisDateTime = BeginOfDay(MiliSecToDate(messages[currentIndex].timestamp_ms));
            this.messages = new List<Message>();

            DateTime currentDate = MiliSecToDate(messages[currentIndex].timestamp_ms);
            ulong lastMiliSec = LastMiliSecAtThisDate(currentDate);
            
            for (; currentIndex < messages.Count && messages[currentIndex].timestamp_ms < lastMiliSec; currentIndex++)
                this.messages.Add(messages[currentIndex]);
        }
        
        private DateTime MiliSecToDate(ulong mili)
            => new DateTime(1970, 1, 1).AddMilliseconds(mili);
        private ulong DateToMiliSec(DateTime date) 
            => (ulong)(date - new DateTime(1970, 1, 1)).TotalMilliseconds;

        private ulong LastMiliSecAtThisDate(DateTime date) 
            => DateToMiliSec(new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999));

        private DateTime BeginOfDay(DateTime date)
            => new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
    }
}
