using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounter.Models
{
    class Word
    {
        public string WordContent { get; }
        public int WordQuantity { get; }

        public Word(string wordContent, int wordQuantity)
        {
            this.WordContent = wordContent;
            this.WordQuantity = wordQuantity;
        }
    }
}
