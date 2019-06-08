using System;
using System.Windows;
using MessageCounterBackend;
using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterFrontend.InterfaceBackend;
using MessageCounterFrontend.SettingsWindows;
using MessageCounterFrontend.InterfaceBackend.FileOperators;
using System.IO;
using MessageCounterFrontend.InfoWindows;
using System.Windows.Controls;

namespace MessageCounterFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPage statsPage;

        private bool IsAnyFileOpened { get => this.statsPage != null; }

        public MainWindow()
        {
            InitializeComponent();

            mainFrame.Navigate(new Page());

            try  // Reading settings file
            {
                using (var reader = new SettingsFileReader(SettingsFileReader.SettingsFilePath))
                    reader.ReadSettings();
            }
            catch { }

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
                TryToLoadTheFile(args);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e) => TryToLoadTheFile(null);

        private void TryToLoadTheFile(string[] args)
        {
            try
            {
                string fileContent;

                if (null == args)   // if from OpenFile_Click
                    using (var reader = new FileReaderWithDialog())
                        fileContent = reader.ReadAll();     // IOException

                else                // if from command line args
                    using (var reader = new FileReaderWithDialog(args[1]))
                        fileContent = reader.ReadAll();     // IOException

                var stats = CreateStatsContainer(fileContent);   // Newtonsoft.Json.JsonReaderException
                this.statsPage = new MainPage(this, stats);
                    
            }
            catch (Exception e)
            {
                HandleExceptionsWhileLoading(e);
                return;
            }

            closeTheFile.IsEnabled = true;
            mainFrame.Navigate(statsPage);
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

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

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

        private void CloseTheFile_Click(object sender, RoutedEventArgs e)
        {
            closeTheFile.IsEnabled = false;
            mainFrame.GoBack();
            statsPage = null;
        }

        private void OpenWordsSettings(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                var window = CreateNewSettingsWindow();

                if (false == window.ShowDialog())
                    break;

                var newValues = window.NewValues;

                if (null == newValues)
                    SorterWordsGroupListMaker.SetDefaultValues();
                else
                {
                    try
                    {
                        (SorterWordsGroupListMaker.MinLenghtOfWords, SorterWordsGroupListMaker.MinAppearsTimesOfWord)
                            = newValues.Value;
                    }
                    catch
                    {
                        continue;
                    }
                }
                break;
            }

            try
            {
                using (var writer = new SettingsFileWriter(SettingsFileWriter.SettingsFilePath))
                    writer.WriteSettings();
            }
            catch
            {
                MessageBox.Show("Problem with file. Settings hasn't been saved.");
            }

            if (this.IsAnyFileOpened)
                this.statsPage.ReloadFile();
        }

        private WordsSettings CreateNewSettingsWindow()
        {
            var window = new WordsSettings()
            {
                Owner = this
            };

            window.minLenght.Text = SorterWordsGroupListMaker.MinLenghtOfWords.ToString();
            window.minAppearsTimes.Text = SorterWordsGroupListMaker.MinAppearsTimesOfWord.ToString();

            return window;
        }

        private void LinkToDataDownloadingPage_Click(object sender, RoutedEventArgs e) 
            => System.Diagnostics.Process.Start(Instructions.LinkToDownloadSite);

        private void OpenInstructions_Click(object sender, RoutedEventArgs e) 
            => mainFrame.Navigate(new Instructions());
    }
}
