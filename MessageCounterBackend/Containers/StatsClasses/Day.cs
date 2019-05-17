using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Day
    {
        public DateTime ThisDateTime { get; set; }
        public int NumberOfMessages => MessagesContainer.NumberOfMessages;
        public MessagesContainer MessagesContainer { get; }

        public Day(List<Message> messages, DateTime date)
        {
            this.ThisDateTime = date;
            this.MessagesContainer = new MessagesContainer(messages);
        }
    }
}
