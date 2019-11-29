using System.Collections.Generic;
using MessageCounterBackend.Containers.StatsClasses.DateNameSpace;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.Containers.StatsClasses
{
    public class Day
    {
        public Date ThisDate { get; set; }
        public int NumberOfMessages => MessagesContainer.NumberOfMessages;
        public MessagesContainer MessagesContainer { get; }

        public Day(List<MessageJson> messages, Date date)
        {
            this.ThisDate = date;
            this.MessagesContainer = new MessagesContainer(messages);
        }
    }
}
