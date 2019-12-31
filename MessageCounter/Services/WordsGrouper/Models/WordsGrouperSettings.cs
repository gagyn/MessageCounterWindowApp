namespace MessageCounter.Services.WordsGrouper.Models
{
    public class WordsGrouperSettings
    {
        private const uint _defaultMinLength = 3;
        private const uint _defaultMinTimes = 5;

        /// <summary>
        /// Words, which are SHORTER, will NOT be included in the list.
        /// </summary>
        public uint MinLengthOfWords
        {
            get => _minLengthOfWords;
            set => _minLengthOfWords = value > 0 ? value : _defaultMinLength;
        }

        /// <summary>
        /// Words, which appeared LESS times, will NOT be included in this list.
        /// </summary>
        public uint MinAppearsTimesOfWord
        {
            get => _minAppearsTimesOfWord;
            set => _minAppearsTimesOfWord = value > 0 ? value : _defaultMinTimes;
        }

        private uint _minAppearsTimesOfWord;
        private uint _minLengthOfWords;

        public WordsGrouperSettings()
        {
            this.MinLengthOfWords = _defaultMinLength;
            this.MinAppearsTimesOfWord = _defaultMinTimes;
        }

        public WordsGrouperSettings(uint minLengthOfWords, uint minAppearsTimesOfWord)
        {
            this.MinLengthOfWords = minLengthOfWords;
            this.MinAppearsTimesOfWord = minAppearsTimesOfWord;
        }
    }
}
