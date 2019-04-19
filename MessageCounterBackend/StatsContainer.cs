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
        public MessagesContainer messagesContainer;
        public DaysContainer daysContainer;
        public PeopleContainer peopleContainer;
        public int NumberOfMessages { get => ((List<Message>)jsonObject.messages).Count; }
        public int NumberOfParticipants { get => ((List<Participant>)jsonObject.participants).Count; }

        private readonly JsonStructureClass jsonObject;

        public StatsContainer(string fileContent)
        {
            this.jsonObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);
        }

        public void MakeMessagesContainer() => this.messagesContainer = new MessagesContainer(jsonObject);
        public void MakeDaysContainer() => this.daysContainer = new DaysContainer(jsonObject);
        public void MakePeopleContainer() => this.peopleContainer = new PeopleContainer(jsonObject);
    }
}
