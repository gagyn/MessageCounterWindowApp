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
    class MessagesGridMaker : GridMaker
    {
        public MessagesGridMaker(Container container) : base(container)
        {
        }

        protected override Grid[] MakeGrids(Container container)
        {
            if (!(container is MessagesContainer messagesContainer))
                throw new ArgumentException();  // if container isn't for messages

            return new Grid[]
            {
                null
            };
        }
    }
}
