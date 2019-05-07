using MessageCounterBackend.Containers.Helpers_classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageCounterFrontend.InterfaceBackend
{
    class FileReader
    {
        public static string SettingsFilePath { get; } = "settings.config";

        private StreamReader reader;

        public FileReader(string path) => reader = new StreamReader(path);
        public string Read() => reader.ReadLine();
        public void ReadSettings()
        {
            SortedWordsGroupListMaker.MinLenghtOfWords = int.Parse(this.Read());
            SortedWordsGroupListMaker.MinAppearsTimesOfWord = int.Parse(this.Read());
        }
        public void Close()
        {
            if (null != reader)
                reader.Dispose();
        }
        ~FileReader() => Close();
    }
}
