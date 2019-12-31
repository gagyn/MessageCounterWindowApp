using System.IO;
using MessageCounter.Services.WordsGrouper;
using MessageCounter.Services.WordsGrouper.Models;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    class SettingsFileReader
    {
        private const string _settingsFilePath = "settings.config";

        public WordsGrouperSettings ReadSettings()
        {
            var settingsFactory = new WordsGrouperSettingsFactory();

            try
            {
                return settingsFactory.Create(File.ReadAllText(_settingsFilePath));
            }
            catch
            {
                return new WordsGrouperSettings();
            }
        }
    }
}
