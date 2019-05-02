using System;
using System.IO;
using Newtonsoft.Json;
using MessageCounterBackend.StatContainers;
using MessageCounterBackend.JsonStructure;
using System.Collections.Generic;

namespace MessageCounterBackend
{
    /// <summary>
    /// The class contains all statistics about messages in the file. Throws exception in constructor if file is incorrect.
    /// </summary>
    public class StatsContainer
    {
        public MessagesContainer MessagesContainer { get; set; }
        public DaysContainer DaysContainer { get; set; }
        public PeopleContainer PeopleContainer { get; set; }

        public int NumberOfMessages { get => (jsonObject.messages as List<Message>).Count; }
        public int NumberOfParticipants { get => (jsonObject.participants as List<Participant>).Count; }

        private readonly JsonStructureClass jsonObject;

        public StatsContainer(string fileContent)
        {
            this.jsonObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);
        }

        public void MakeMessagesContainer() => this.MessagesContainer = new MessagesContainer(jsonObject);
        public void MakeDaysContainer() => this.DaysContainer = new DaysContainer(jsonObject);
        public void MakePeopleContainer() => this.PeopleContainer = new PeopleContainer(jsonObject);
    }
}
