using MessageCounterBackend.Containers.Helpers_classes;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    class SettingsFileReader : FileReader
    {
        public static string SettingsFilePath { get; } = "settings.config";

        public SettingsFileReader(string path) : base(path) { }

        public void ReadSettings()
        {
            SorterWordsGroupListMaker.MinLenghtOfWords = int.Parse(base.ReadLine());
            SorterWordsGroupListMaker.MinAppearsTimesOfWord = int.Parse(base.ReadLine());
        }
    }
}
