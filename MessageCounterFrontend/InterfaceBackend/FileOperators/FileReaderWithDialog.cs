using Microsoft.Win32;
using System;
using System.IO;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    class CanceledByUserException : Exception
    {

    }

    internal class FileReaderWithDialog : IDisposable
    {
        private readonly StreamReader streamReader;
        private bool disposed = false;
        public FileReaderWithDialog()
        {
            var openFileD = new OpenFileDialog();
            if (openFileD.ShowDialog() == true)
                streamReader = new StreamReader(openFileD.FileName);
            else
                throw new CanceledByUserException();
        }

        public string ReadToEnd() => streamReader.ReadToEnd();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                this.streamReader?.Dispose();

            this.disposed = true;
        }
        ~FileReaderWithDialog() => this.Dispose();
    }
}
