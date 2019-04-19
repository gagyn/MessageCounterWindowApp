using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MessageCounterBackend.StatContainers;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterFrontend.InterfaceBackend.ContainersTextBoxMakers
{
    static class MessagesTextMaker
    {
        public static TextBlock MakeTextBlock(MessagesContainer container)
        {
            string content = "";



            return new TextBlock()
            {
                Text = content
            };
        }
    }
}
