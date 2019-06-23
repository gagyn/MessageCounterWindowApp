using Newtonsoft.Json;
using MessageCounterBackend.JsonStructure;
using System.Collections.Generic;
using MessageCounterBackend.Containers;
using System.Linq;

namespace MessageCounterBackend
{
    /// <summary>
    /// The class contains all statistics about messages in the file. Throws exception in constructor if file is incorrect.
    /// </summary>
    public class StatsContainer
    {
        public MessagesContainer WordsContainer
        {
            get
            {
                if (this.wordsContainer == null)
                    this.wordsContainer = new MessagesContainer(JsonObject);
                return this.wordsContainer;
            }

            set => this.wordsContainer = value;
        }
        public DaysContainer DaysContainer
        {
            get
            {
                if (this.daysContainer == null)
                    this.daysContainer = new DaysContainer(JsonObject); 
                return this.daysContainer;
            }

            set => this.daysContainer = value;
        }
        public PeopleContainer PeopleContainer
        {
            get
            {
                if (this.peopleContainer == null)
                    this.peopleContainer = new PeopleContainer(JsonObject);
                return this.peopleContainer;
            }

            set => this.peopleContainer = value;
        }

        public JsonStructureClass JsonObject { get; }


        private MessagesContainer wordsContainer;
        private DaysContainer daysContainer;
        private PeopleContainer peopleContainer;

        public StatsContainer(string fileContent)
            => this.JsonObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);

        public void ReloadContainers()
        {
            WordsContainer = null;
            DaysContainer = null;
            PeopleContainer = null;
        }
    }
}
