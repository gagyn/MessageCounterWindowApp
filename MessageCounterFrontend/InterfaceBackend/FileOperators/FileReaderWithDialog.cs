using Microsoft.Win32;
using System;
using System.IO;
using MessageCounterFrontend.MainWindowOperations;

namespace MessageCounterFrontend.InterfaceBackend.FileOperators
{
    internal class FileReaderWithDialog : IDisposable
    {
        private readonly StreamReader _streamReader;
        private bool _disposed = false;
        public FileReaderWithDialog()
        {
            var openFileD = new OpenFileDialog();
            if (openFileD.ShowDialog() == true)
                _streamReader = new StreamReader(openFileD.FileName);
            else
                throw new CanceledByUserException();
        }

        public string ReadToEnd() => _streamReader.ReadToEnd();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
                this._streamReader?.Dispose();

            this._disposed = true;
        }
        ~FileReaderWithDialog() => this.Dispose();
    }
}
