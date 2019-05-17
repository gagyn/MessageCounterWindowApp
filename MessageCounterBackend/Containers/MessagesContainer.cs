using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.StatContainers
{
    public class MessagesContainer : Container
    {
        public List<Message> Messages { get; }
        public int NumberOfMessages => Messages.Count;
        public int NumberOfWords => SortedWordsByFrequents.Count;
        public List<IGrouping<string, string>> SortedWordsByFrequents { get; }

        public MessagesContainer(JsonStructureClass jsonObject) 
            : this(jsonObject.messages.ToList()) { }
        public MessagesContainer(List<Message> messages)
        {
            this.Messages = messages;
            var sorter = new SorterWordsGroupListMaker(this.Messages);
            SortedWordsByFrequents = sorter.SortedWordsByFrequents;
        }
    }
}
