using System;
using System.IO;
using Newtonsoft.Json;
using MessageCounterBackend.StatClasses;

namespace MessageCounterBackend
{
    /// <summary>
    /// The class contains all statistics about messages in the file. Throws exception in constructor if file is incorrect.
    /// </summary>
    public class StatsContainer
    {
        private readonly JsonStructureClass jsonObject;
        private readonly MessagesContainer messages;

        public int NumberOfMessages { get => messages.NumberOfMessages; }

        public StatsContainer(string fileContent)
        {
            this.jsonObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);
            this.messages = new MessagesContainer(jsonObject);
        }
    }
}
