using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MessageCounterFrontend.InterfaceBackend
{
    internal class TextBlockMaker
    {
        public bool IncludePeople { get; set; }
        public bool IncludeDays { get; set; }
        public bool IncludeMessages { get; set; }
        public TextBlock GetTextBlock() => textBox;

        private readonly TextBlock textBox;
        public TextBlockMaker(MessageCounterBackend.StatsContainer statsContainer)
        {
            this.textBox = new TextBlock()
            {
                Text = PrepareStatsToString(statsContainer)
            };
        }

        private string PrepareStatsToString(MessageCounterBackend.StatsContainer statsContainer)
        {
            string content;
            content = "Number of all message in this conversation: " + statsContainer.NumberOfMessages.ToString();


            return content;
        }
    }
}
