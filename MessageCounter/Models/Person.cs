using System.Collections.Generic;
using System.Linq;
using MessageCounter.Models.Factories;
using MessageCounter.Services.WordsGrouper;

namespace MessageCounter.Models
{
    public class Person
    {
        public string Name { get; }
        public List<Message> Messages { get; }
        public List<Word> Words { get; }
        public List<Day> DaysWhenPersonWroteAny { get; }
        public double ConversationMessagesRatio => Messages.Count / (double)_allMessageQuantity;
        public double ConversationWordsRatio => Words.Count / (double)_allWordsQuantity;

        private readonly int _allMessageQuantity;
        private readonly int _allWordsQuantity;

        public Person(string name, List<Message> messages, int allMessagesQuantity, int allWordsQuantity)
        {
            this.Name = name;
            this.Messages = messages;
            this._allMessageQuantity = allMessagesQuantity;
            this._allWordsQuantity = allWordsQuantity;

            var grouper = new WordsGrouperService(messages);
            this.Words = grouper.GroupWords().ToList();

            
        }
    }
}
