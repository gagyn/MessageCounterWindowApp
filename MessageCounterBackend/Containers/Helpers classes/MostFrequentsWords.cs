using MessageCounterBackend.JsonStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageCounterBackend.Containers.Helpers_classes
{
    internal class MostFrequentsWords
    {
        /// <summary>
        /// Words, which are SHORTER, will NOT be included in the list.
        /// </summary>
        public int MinLenghtOfWords { get; set; } = 3;

        /// <summary>
        /// Words, which appeared LESS, will NOT be included in this list.
        /// </summary>
        public int MinAppearsTimesOfWord { get; set; } = 2;

        /// <summary>
        /// Sorted list with all words, which meet the conditions (default: minlenght = 3; minAppearsTimes = 2)
        /// </summary>
        public List<IGrouping<string, string>> SortedWordsByFrequents { get => SortedWords(); }

        private List<Message> messages;

        public MostFrequentsWords(List<Message> messages) => this.messages = messages;

        private List<IGrouping<string, string>> SortedWords()
        {
            Char[] charToRemove =
                { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=',
            '{', '[', '}', ']', ':', ';', '\"', '\'', '|', '\\', '<', ',', '>', '.', '?', '/', '\u201e', '\u201d' };
            // I make it in this way, bcs I want to remove only special characters,
            // but not special leters in different langs (like: 'Ą','Ź')

            var sortedWords =
                from message in (this.messages as IEnumerable<Message>)
                where message.content != null
                let decodedLowerMessage = message.content.DecodeString().ToLower()
                from word in decodedLowerMessage.Split()
                let trimmedWord = word.Trim(charToRemove)
                where trimmedWord.Length >= MinLenghtOfWords
                group trimmedWord by trimmedWord into groupedWords
                orderby groupedWords.Count()
                select groupedWords;

            var reversed = sortedWords.Reverse();
            reversed = reversed.Where(x => x.Count() >= MinAppearsTimesOfWord);

            return reversed.ToList();
        }
    }
}
