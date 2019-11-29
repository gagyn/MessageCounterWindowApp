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
            base.WriteLine(GroupWords.MinLengthOfWords.ToString());
            base.WriteLine(GroupWords.MinAppearsTimesOfWord.ToString());
        }
    }
}
