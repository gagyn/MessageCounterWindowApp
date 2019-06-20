using System.IO;
using MessageCounterBackend.Containers.Helpers_classes;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    class SettingsFileWriter : StreamWriter
    {
        public static string SettingsFilePath { get; } = "settings.config";

        public SettingsFileWriter(string path) : base(path) { }

        public void WriteSettings()
        {
            base.WriteLine(SorterWordsGroupListMaker.MinLenghtOfWords.ToString());
            base.WriteLine(SorterWordsGroupListMaker.MinAppearsTimesOfWord.ToString());
        }
    }
}
