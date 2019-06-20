using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounterBackend.Containers.StatsClasses
{
    public class Word
    {
        public string Text { get; set; }
        public int NumberOfOccurrences { get; set; }

        public Word(string text, int numberOfOccurrences)
        {
            this.Text = text;
            this.NumberOfOccurrences = numberOfOccurrences;
        }
    }
}
