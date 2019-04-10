using System;
using System.Collections.Generic;
using System.Text;

namespace MessageCounterBackend.StatClasses
{
    internal class MessagesContainer
    {
        private readonly List<Message> messages;

        public MessagesContainer(JsonStructureClass jsonObject)
        {
            this.messages = (List<Message>)jsonObject.messages;
        }
    }
}
