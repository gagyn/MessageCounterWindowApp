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
        private readonly TextBlock textBox;
        public TextBlock GetTextBlock() => textBox;

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
