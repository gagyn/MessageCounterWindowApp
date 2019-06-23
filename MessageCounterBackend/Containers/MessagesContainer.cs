using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterBackend.Containers.StatsClasses;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.Containers
{
    public class MessagesContainer : Container
    {
        public List<Message> Messages { get; }
        public int NumberOfMessages => Messages.Count;
        public int NumberOfUniqueWords => SortedWords.Count;
        public int NumberOfAllWords
        {
            get
            {
                int count = 0;

                foreach (var word in SortedWords)
                    count += word.NumberOfOccurrences;
                return count;
            }
        }

        public List<Word> SortedWords { get; }

        public MessagesContainer(JsonStructureClass jsonObject) 
            : this(jsonObject.messages.ToList()) { }
        public MessagesContainer(List<Message> messages)
        {
            this.Messages = messages;

            if (messages.Count == 0)
            {
                SortedWords = new List<Word>();
                return;
            }

            var sorter = new SorterWordsGroupListMaker(this.Messages);
            var groupedSortedWords = sorter.SortedWordsByFrequents;

            var words = groupedSortedWords.Select(x => new Word(x.Key, x.Count()));

            SortedWords = words.ToList();
        }
    }
}
