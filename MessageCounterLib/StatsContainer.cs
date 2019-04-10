using System;
using System.IO;
using Newtonsoft.Json;
using MessageCounterBackend.StatClasses;

namespace MessageCounterBackend
{
    public class StatsContainer
    {
        private JsonStructureClass jsonObject;

        private MessagesContainer messages;


        public StatsContainer(string path)
        {
            LoadJsonFile(path);
            messages = new MessagesContainer(jsonObject);
        }

        void LoadJsonFile(string path)
        {
            var x = 6;
            string fileContent;
            try
            {
                var streamReader = new StreamReader(path);
                fileContent = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is IOException)
                    throw new Exception("FileException");
                else
                    throw e;
            }

            try
            {
                jsonObject = JsonConvert.DeserializeObject<JsonStructureClass>(fileContent);
            }
            catch (Exception e)
            {
                throw new Exception("JsonException", e);
            }
        }
    }
}
