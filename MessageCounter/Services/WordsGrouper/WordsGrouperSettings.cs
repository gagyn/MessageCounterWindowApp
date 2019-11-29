using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounter.Services.WordsGrouper
{
    public class WordsGrouperSettings
    {
        private const uint defaultMinLength = 3;
        private const uint defaultMinTimes = 5;

        /// <summary>
        /// Words, which are SHORTER, will NOT be included in the list.
        /// </summary>
        public uint MinLengthOfWords
        {
            get => _minLengthOfWords;
            set => _minLengthOfWords = value > 0 ? value : defaultMinLength;
        }

        /// <summary>
        /// Words, which appeared LESS times, will NOT be included in this list.
        /// </summary>
        public uint MinAppearsTimesOfWord
        {
            get => _minAppearsTimesOfWord;
            set => _minAppearsTimesOfWord = value > 0 ? value : defaultMinTimes;
        }

        private uint _minAppearsTimesOfWord;
        private uint _minLengthOfWords;

        public WordsGrouperSettings()
        {
            this.MinLengthOfWords = defaultMinLength;
            this.MinAppearsTimesOfWord = defaultMinTimes;
        }

        public WordsGrouperSettings(uint minLengthOfWords, uint minAppearsTimesOfWord)
        {
            this.MinLengthOfWords = minLengthOfWords;
            this.MinAppearsTimesOfWord = minAppearsTimesOfWord;
        }
    }
}
