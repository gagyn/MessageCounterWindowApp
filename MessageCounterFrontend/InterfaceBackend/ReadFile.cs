using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MessageCounterFrontend.InterfaceBackend
{
    internal class ReadFile
    {
        private readonly string fileName;

        public ReadFile()
        {
            var openFileD = new OpenFileDialog();
            if (openFileD.ShowDialog() == true)
                this.fileName = openFileD.FileName;
            else
                throw new Exception("CanceledByUser");
        }
        public ReadFile(string fileName) => this.fileName = fileName;

        public string Read() => new StreamReader(fileName).ReadToEnd();
    }
}
