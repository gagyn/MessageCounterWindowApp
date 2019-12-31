using MessageCounter.Models;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    internal class WordStrings
    {
        public Word Word { get; }

        public string Text => Word.WordContent;
        public int NumberOfOccurrences => Word.WordQuantity;

        public WordStrings(Word word) => this.Word = word;
    }
}
