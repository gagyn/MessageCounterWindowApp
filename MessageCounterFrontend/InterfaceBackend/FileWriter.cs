using MessageCounterBackend.Containers.Helpers_classes;
using System.IO;

namespace MessageCounterFrontend.InterfaceBackend
{
    class FileWriter
    {
        public static string SettingsFilePath { get; } = "settings.config";

        private readonly StreamWriter writer;

        public FileWriter(string path) => writer = new StreamWriter(path);
        public void Write(string content) => writer.WriteLine(content);
        public void WriteSortedWordsGroup()
        {
            this.Write(SortedWordsGroupListMaker.MinLenghtOfWords.ToString());
            this.Write(SortedWordsGroupListMaker.MinAppearsTimesOfWord.ToString());
        }
        public void Close()
        {
            if (null != writer)
                writer.Dispose();
        }
        ~FileWriter() => Close();
    }
}
