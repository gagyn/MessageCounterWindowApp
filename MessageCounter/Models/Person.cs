using System.Collections.Generic;

namespace MessageCounter.Models
{
    public class Person
    {
        public string Name { get; }
        public List<Message> Messages { get; }
        public List<Word> Words { get; }

        public double SentMessagesRatio => Messages.Count / (double)_allMessageQuantity;

        private double SentAllWordsRatio => Words.Count / (double)_allWordsQuantity;

        private readonly int _allMessageQuantity;
        private readonly int _allWordsQuantity;

        public Person(string name, List<Message> messages, int allMessagesQuantity, int allWordsQuantity)
        {
            Name = name;
            Messages = messages;
            this._allMessageQuantity = allMessagesQuantity;
            _allWordsQuantity = allWordsQuantity;

            
        }
    }
}
