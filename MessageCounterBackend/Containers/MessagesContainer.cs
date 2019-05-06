using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.StatContainers
{
    public class MessagesContainer : Container
    {
        public List<Message> Messages { get; }

        public int NumberOfMessages { get => Messages.Count; }
        public List<IGrouping<string, string>> SortedWordsByFrequents { get; private set; }

        public MessagesContainer(JsonStructureClass jsonObject) 
            : this(jsonObject.messages.ToList()) { }
        public MessagesContainer(List<Message> messages)
        {
            this.Messages = messages;
            var sorter = new SortedWordsGroupListMaker(this.Messages)
            {
                // TODO: reading settings from file
            };
            SortedWordsByFrequents = sorter.SortedWordsByFrequents;
        }
    }
}
