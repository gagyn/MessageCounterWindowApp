using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageCounterBackend.Containers.StatsClasses;

namespace MessageCounterFrontend.Pages.StatsPages.StringsForPages
{
    class WordStrings
    {
        public Word Word { get; set; }

        public string Text => Word.Text;
        public int NumberOfOccurrences => Word.NumberOfOccurrences;

        public WordStrings(Word word) => this.Word = word;
    }
}
