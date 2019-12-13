using MessageCounter.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MessageCounter
{
    class StatisticsManagerFactory
    {
        private readonly string _fileContent;

        public StatisticsManagerFactory(string fileContent)
        {
            this._fileContent = fileContent;
        }

        public StatisticsManager Create()
        {
            var jsonDataObject = JsonConvert.DeserializeObject<JsonStructureClass>(this._fileContent);

            throw new NotImplementedException();
            return new StatisticsManager(null, null, null);
        }
    }
}
