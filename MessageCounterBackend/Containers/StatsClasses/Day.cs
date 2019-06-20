using System.Collections.Generic;
using MessageCounterBackend.Containers.StatsClasses.Date;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.StatContainers.ListTypesClasses
{
    public class Day
    {
        public Date ThisDate { get; set; }
        public int NumberOfMessages => MessagesContainer.NumberOfMessages;
        public MessagesContainer MessagesContainer { get; }

        public Day(List<Message> messages, Date date)
        {
            this.ThisDate = date;
            this.MessagesContainer = new MessagesContainer(messages);
        }
    }
}
