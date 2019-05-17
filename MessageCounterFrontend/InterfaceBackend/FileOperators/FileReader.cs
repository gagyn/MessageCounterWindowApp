using System;
using System.IO;

namespace MessageCounterFrontend.InterfaceBackend
{
    class FileReader : IDisposable
    {
        protected StreamReader reader;
        private bool disposed = true;

        protected FileReader() { }
        public FileReader(string path)
        {
            reader = new StreamReader(path);
            disposed = false;
        }

        public string ReadLine() => reader.ReadLine();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                this.reader?.Dispose();
            
            this.disposed = true;
        }

        ~FileReader() => this.Dispose();
    }
}
