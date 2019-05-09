using MessageCounterBackend.JsonStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageCounterBackend.Containers.Helpers_classes
{
    /// <summary>
    /// Group words, then sorts by frequents of appearing, set result to SortedWordsByFrequents.
    /// </summary>
    public class SortedWordsGroupListMaker
    {
        /// <summary>
        /// Words, which are SHORTER, will NOT be included in the list.
        /// </summary>
        public static int MinLenghtOfWords
        {
            get => minLenghtOfWords;
            set
            {
                if (value > 0)
                    minLenghtOfWords = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Words, which appeared LESS times, will NOT be included in this list.
        /// </summary>
        public static int MinAppearsTimesOfWord
        {
            get => minAppearsTimesOfWord;
            set
            {
                if (value > 0)
                    minAppearsTimesOfWord = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Sorted list with all words, which meet the conditions (default: minlenght = 3; minAppearsTimes = 2)
        /// </summary>
        public List<IGrouping<string, string>> SortedWordsByFrequents { get => SortedWords(); }

        private static int minAppearsTimesOfWord;
        private static int minLenghtOfWords;
        private readonly List<Message> messages;

        static SortedWordsGroupListMaker() => SetDefaultValues();
        public SortedWordsGroupListMaker(List<Message> messages) => this.messages = messages;

        public static void SetDefaultValues()
        {
            minLenghtOfWords = 3;
            minAppearsTimesOfWord = 5;
        }

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
