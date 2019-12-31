using MessageCounter.Models;
using System.Collections.Generic;
using System.Linq;
using MessageCounter.Services.StringDecoder;
using MessageCounter.Services.WordsGrouper.Models;

namespace MessageCounter.Services.WordsGrouper
{
    public class WordsGrouperService
    {
        public WordsGrouperSettings GrouperSettings { get; set; }

        private readonly IEnumerable<Message> _messages;

        public WordsGrouperService(Message message)
        {
            _messages = new List<Message>()
            {
                message
            };
            GrouperSettings = new WordsGrouperSettings();
        }

        public WordsGrouperService(IEnumerable<Message> messages)
        {
            _messages = messages;
            GrouperSettings = new WordsGrouperSettings();
        }

        public IEnumerable<Word> GroupWords()
        {
            char[] charToRemove =
                { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=',
            '{', '[', '}', ']', ':', ';', '\"', '\'', '|', '\\', '<', ',', '>', '.', '?', '/', ' ', '\u201e', '\u201d' };
            // I make it in this way, bcs I want to remove only special characters,
            // but not special letters in different langs (like: 'Ą','Ź')

            var messages = this._messages.Where(x => x.Content != null)
                .Select(x => x.Content.ToLowerInvariant().DecodeString());

            var words = messages.SelectMany(msg => msg.Split())
                .Select(word => word.Trim(charToRemove))
                .Where(word => word.Length >= GrouperSettings.MinLengthOfWords);

            var groupedWords = words
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Where(x => x.Count() >= GrouperSettings.MinAppearsTimesOfWord);

            return groupedWords.Select(x => new Word(x.Key, x.Count()));
        }
    }
}
