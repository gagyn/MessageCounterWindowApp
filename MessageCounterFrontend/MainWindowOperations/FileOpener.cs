using MessageCounterBackend;
using MessageCounterFrontend.InterfaceBackend.FileOperators;
using MessageCounterFrontend.Pages;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace MessageCounterFrontend.MainWindowOperations
{
    class FileOpener
    {
        /// <summary>
        /// StatsPage IS NULL if there was any exception (problem with file / canceled by user)
        /// </summary>
        public MainPage StatsPage { get; private set; }
        
        public FileOpener() // if from OpenFile_Click
        {
            try
            {
                string fileContent;

                using (var reader = new FileReaderWithDialog())
                    fileContent = reader.ReadToEnd();

                AssignStatsPage(fileContent);
            }
            catch (Exception e)
            {
                HandleExceptionsWhileLoading(e);
                throw;
            }
        }

        public FileOpener(string path)  // if from command args
        {
            try
            {
                string fileContent;

                using (var reader = new StreamReader(path))
                    fileContent = reader.ReadToEnd();

                AssignStatsPage(fileContent);
            }
            catch (Exception e)
            {
                HandleExceptionsWhileLoading(e);
                throw;
            }
        }

        private void AssignStatsPage(string fileContent)
        {
            var stats = new StatsContainer(fileContent); // constructor throws exception, when file is incorrect
            StatsPage = new MainPage(stats);
        }

        private void HandleExceptionsWhileLoading(Exception e)
        {
            switch (e)
            {
                case IOException _:
                    MessageBox.Show("Problem with opening the file.");
                    break;

                case JsonSerializationException _:
                    MessageBox.Show("Problem with parsing the file - the file is incorrect. Make sure the file is a correct message history file.");
                    break;

                case CanceledByUserException _:
                    break;

                default:
                    MessageBox.Show("Uknown problem: " + e.Message);
                    break;
            }
        }
    }
}
