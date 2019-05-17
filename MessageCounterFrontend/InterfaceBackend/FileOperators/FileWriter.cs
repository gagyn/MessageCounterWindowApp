using System;
using System.IO;

namespace MessageCounterFrontend.InterfaceBackend
{
    class FileWriter : IDisposable
    {
        private readonly StreamWriter writer;
        private bool disposed = true;

        public FileWriter(string path)
        {
            writer = new StreamWriter(path);
            disposed = false;
        }

        public void Write(string content) => writer.WriteLine(content);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                this.writer?.Dispose();

            this.disposed = true;
        }

        ~FileWriter() => this.Dispose();
    }
}
