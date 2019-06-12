using MessageCounterBackend;
using MessageCounterFrontend.InterfaceBackend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessageCounterFrontend.MainWindowOperations
{
    class FileOpener
    {
        public MainPage StatsPage { get; private set; }

        private MainWindow Window { get; }

        /// <summary>
        /// StatsPage IS NULL if there was any exception (problem with file / canceled by user)
        /// </summary>
        public FileOpener(MainWindow window) : this(window, null) { }
        public FileOpener(MainWindow window, string path)
        {
            Window = window;
            TryToLoadTheFile(path); // TODO: Refactor this method
        }

        private void TryToLoadTheFile(string path)
        {
            try
            {
                string fileContent;

                if (null == path)   // if from OpenFile_Click
                    using (var reader = new FileReaderWithDialog()) // CanceledByUserException
                        fileContent = reader.ReadAll();     // IOException

                else                // if from command line args
                    using (var reader = new FileReaderWithDialog(path))
                        fileContent = reader.ReadAll();     // IOException

                var stats = CreateStatsContainer(fileContent);   // Newtonsoft.Json.JsonReaderException
                StatsPage = new MainPage(Window, stats);
            }
            catch (Exception e)
            {
                HandleExceptionsWhileLoading(e);
                return;
            }
        }

        private void HandleExceptionsWhileLoading(Exception e)
        {
            if (e is IOException)
                MessageBox.Show("Problem with opening the file: " + e.Message);

            else if (e is Newtonsoft.Json.JsonSerializationException)
                return;

            else if (e is CanceledByUserException)
                return;

            else
                MessageBox.Show("Unknown problem: " + e.Message);
        }

        private StatsContainer CreateStatsContainer(string fileContent) // throw exception, when file is incorrect
        {
            try
            {
                return new StatsContainer(fileContent);
            }
            catch
            {
                MessageBox.Show("The file is incorrect!");
                throw;
            }
        }
    }
}
