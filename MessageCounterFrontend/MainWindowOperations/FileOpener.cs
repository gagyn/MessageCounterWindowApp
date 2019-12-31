using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace MessageCounterFrontend.MainWindowOperations
{
    public class CanceledByUserException : Exception
    {
    }

    public class FileOpener
    {
        private readonly string _path;

        public FileOpener()
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == false) 
                throw new CanceledByUserException();

            this._path = fileDialog.FileName;
        }

        public FileOpener(string path)
        {
            this._path = path;
        }

        public string? ReadContent()
        {
            try
            {
                using var reader = new StreamReader(this._path);
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                HandleExceptionsWhileLoading(e);
                return null;
            }
        }

        private void HandleExceptionsWhileLoading(Exception e)
        {
            switch (e)
            {
                case IOException _:
                    MessageBox.Show("Problem with opening the file.");
                    break;
                case Newtonsoft.Json.JsonSerializationException _: //todo: move it somewhere else
                    MessageBox.Show(
                        "Problem with parsing the file - the file is incorrect. Make sure the file is a correct message history file.");
                    break;
                default:
                    MessageBox.Show("Unknown problem: " + e.Message);
                    break;
            }
        }
    }
}
