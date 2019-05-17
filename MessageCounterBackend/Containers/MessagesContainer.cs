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
        public int NumberOfUniqueWords => SortedWordsByFrequents.Count;
        public int NumberOfAllWords => GetNumberOfAllWords();

        public List<IGrouping<string, string>> SortedWordsByFrequents { get; }

        public MessagesContainer(JsonStructureClass jsonObject) 
            : this(jsonObject.messages.ToList()) { }
        public MessagesContainer(List<Message> messages)
        {
            this.Messages = messages;
            var sorter = new SorterWordsGroupListMaker(this.Messages);
            SortedWordsByFrequents = sorter.SortedWordsByFrequents;
        }

        private int GetNumberOfAllWords()
        {
            int count = 0;

            foreach (var gr in SortedWordsByFrequents)
                count += gr.ToList().Count;
            return count;
        }
    }
}
