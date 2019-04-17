using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounterBackend.StatClasses
{
    internal class MessagesContainer
    {
        private readonly List<Message> messages;


        public int NumberOfMessages { get => messages.Count; }

        public MessagesContainer(JsonStructureClass jsonObject)
        {
            this.messages = (List<Message>)jsonObject.messages;
        }
    }
}
