using System.Collections.Generic;
using System.Linq;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.Containers.Helpers_classes
{
    /// <summary>
    /// Group words, then sorts by frequents of appearing, set result to SortedWordsByFrequents.
    /// </summary>
    public class GroupWords
    {
        /// <summary>
        /// Words, which are SHORTER, will NOT be included in the list.
        /// </summary>
        public static int MinLengthOfWords
        {
            get => _minLengthOfWords;
            set => _minLengthOfWords = value > 0 ? value : 1;
        }

        /// <summary>
        /// Words, which appeared LESS times, will NOT be included in this list.
        /// </summary>
        public static int MinAppearsTimesOfWord
        {
            get => _minAppearsTimesOfWord;
            set => _minAppearsTimesOfWord = value > 0 ? value : 1;
        }

        /// <summary>
        /// Sorted list with all words, which meet the conditions (default: minlength = 3; minAppearsTimes = 2)
        /// </summary>
        public IEnumerable<IGrouping<string, string>> SortedWordsByFrequents => SortedWords();

        private static int _minAppearsTimesOfWord;
        private static int _minLengthOfWords;
        private readonly IEnumerable<MessageJson> _messages;

        static GroupWords()
        {
            SetDefaultValues();
        }

        public GroupWords(IEnumerable<MessageJson> messages)
        {
            _messages = messages;
        }

        public static void SetDefaultValues()
        {
            _minLengthOfWords = 3;
            _minAppearsTimesOfWord = 5;
        }

        private IEnumerable<IGrouping<string, string>> SortedWords()
        {
            char[] charToRemove =
                { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=',
            '{', '[', '}', ']', ':', ';', '\"', '\'', '|', '\\', '<', ',', '>', '.', '?', '/', '\u201e', '\u201d' };
            // I make it in this way, bcs I want to remove only special characters,
            // but not special letters in different langs (like: 'Ą','Ź')

            var messages = this._messages.Where(x => x.content != null)
                .Select(x => x.content.DecodeString().ToLowerInvariant());

            var words = messages.SelectMany(msg => msg.Split())
                .Select(word => word.Trim())
                .Where(word => word.Length >= MinLengthOfWords);

            var groupedWords = words.GroupBy(x => x)
                .OrderByDescending(x => x.Count());
            
            var groupedWords2 =
                from message in this._messages
                where message.content != null
                let decodedLowerMessage = message.content.DecodeString().ToLowerInvariant()
                from word in decodedLowerMessage.Split()
                let trimmedWord = word.Trim(charToRemove)
                where trimmedWord.Length >= MinLengthOfWords
                group trimmedWord by trimmedWord into groupedWords3
                orderby groupedWords.Count() descending
                select groupedWords;

            return groupedWords.Where(x => x.Count() >= MinAppearsTimesOfWord);
        }
    }
}
