using MessageCounter.Models;
using System.Collections.Generic;
using System.Linq;

namespace MessageCounter.Services.WordsGrouper
{
    public class WordsGrouper
    {
        private readonly IEnumerable<Message> _messages;
        private readonly WordsGrouperSettings _grouperSettings;

        public WordsGrouper(Message message)
        {
            _messages = new List<Message>()
            {
                message
            };
            _grouperSettings = new WordsGrouperSettings();
        }

        public WordsGrouper(IEnumerable<Message> messages)
        {
            _messages = messages;
        }

        public WordsGrouper(Message message, WordsGrouperSettings grouperSettings) : this(message)
        {
            _grouperSettings = grouperSettings;
        }

        public WordsGrouper(IEnumerable<Message> messages, WordsGrouperSettings grouperSettings) : this(messages)
        {
            _grouperSettings = grouperSettings;
        }

        public IEnumerable<IGrouping<string, string>> GroupWords()
        {
            char[] charToRemove =
                { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=',
            '{', '[', '}', ']', ':', ';', '\"', '\'', '|', '\\', '<', ',', '>', '.', '?', '/', '\u201e', '\u201d' };
            // I make it in this way, bcs I want to remove only special characters,
            // but not special letters in different langs (like: 'Ą','Ź')

            var messages = this._messages.Where(x => x.Content != null)
                .Select(x => x.Content.ToLowerInvariant());

            var words = messages.SelectMany(msg => msg.Split())
                .Select(word => word.Trim())
                .Where(word => word.Length >= _grouperSettings.MinLengthOfWords);

            var groupedWords = words.GroupBy(x => x)
                .OrderByDescending(x => x.Count());

            return groupedWords.Where(x => x.Count() >= _grouperSettings.MinAppearsTimesOfWord);
        }
    }
}
