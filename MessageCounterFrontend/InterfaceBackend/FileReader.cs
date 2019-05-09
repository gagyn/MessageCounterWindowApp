using MessageCounterBackend.Containers.Helpers_classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageCounterFrontend.InterfaceBackend
{
    class FileReader : IDisposable
    {
        public static string SettingsFilePath { get; } = "settings.config";

        protected StreamReader reader;
        private bool disposed = false;

        protected FileReader() { }
        public FileReader(string path) => reader = new StreamReader(path);
        public string Read() => reader.ReadLine();
        public void ReadSettings()
        {
            SortedWordsGroupListMaker.MinLenghtOfWords = int.Parse(this.Read());
            SortedWordsGroupListMaker.MinAppearsTimesOfWord = int.Parse(this.Read());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.reader.Dispose();
            }
            this.disposed = true;
        }

        ~FileReader() => this.Dispose();
    }
}
