using System;
using System.Collections.Generic;
using System.Text;
using MessageCounterBackend.JsonStructure;

namespace MessageCounterBackend.StatContainers
{
    public class MessagesContainer : Container
    {
        private readonly List<Message> messages;

        public int NumberOfMessages { get => messages.Count; }

        public MessagesContainer(JsonStructureClass jsonObject)
        {
            this.messages = (List<Message>)jsonObject.messages;
        }
    }
}
