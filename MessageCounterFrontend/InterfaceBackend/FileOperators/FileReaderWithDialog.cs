using Microsoft.Win32;
using System;
using System.IO;

namespace MessageCounterFrontend.InterfaceBackend
{
    class CanceledByUserException : Exception
    {

    }

    internal class FileReaderWithDialog : FileReader
    {
        public FileReaderWithDialog()
        {
            var openFileD = new OpenFileDialog();
            if (openFileD.ShowDialog() == true)
                base.reader = new StreamReader(openFileD.FileName);
            else
                throw new CanceledByUserException();
        }
        public FileReaderWithDialog(string path) : base(path) { }

        public string ReadAll() => base.reader.ReadToEnd();
    }
}
