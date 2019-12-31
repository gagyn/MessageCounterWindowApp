using System.IO;
using MessageCounter.Services.WordsGrouper.Models;
using Newtonsoft.Json;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    class SettingsFileWriter : SettingsFile
    {
        public void WriteSettings(WordsGrouperSettings grouperSettings)
        {
            File.WriteAllText(_settingsFilePath, JsonConvert.SerializeObject(grouperSettings));
        }
    }
}
