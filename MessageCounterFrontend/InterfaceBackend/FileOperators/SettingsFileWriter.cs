using MessageCounterBackend.Containers.Helpers_classes;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    class SettingsFileWriter : FileWriter
    {
        public static string SettingsFilePath { get; } = "settings.config";

        public SettingsFileWriter(string path) : base(path) { }

        public void WriteSettings()
        {
            base.Write(SorterWordsGroupListMaker.MinLenghtOfWords.ToString());
            base.Write(SorterWordsGroupListMaker.MinAppearsTimesOfWord.ToString());
        }
    }
}
