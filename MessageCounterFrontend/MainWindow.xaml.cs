using System;
using System.Windows;
using System.Windows.Controls;
using MessageCounterBackend;
using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterFrontend.InterfaceBackend;
using MessageCounterFrontend.SettingsWindows;
using MessageCounterFrontend.InterfaceBackend.FileOperators;
using System.IO;

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

            try  // Reading settings file
            {
                using (var reader = new SettingsFileReader(SettingsFileReader.SettingsFilePath))
                    reader.ReadSettings();
            }
            catch { }

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                try
                {
                    using (var reader = new FileReaderWithDialog(args[1]))
                    {
                        var fileContent = reader.ReadAll();
                        var stats = CreateStatsContainer(fileContent);
                        this.statsPage = new MainPage(this, stats);
                    }

                }
                catch
                {
                    //TODO: catch
                    return;
                }

                closeTheFile.IsEnabled = true;
                mainFrame.Navigate(statsPage);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        private void SingleFile_Click(object sender, RoutedEventArgs e)
        {
            string fileContent;
            try
            {
                using (var reader = new FileReaderWithDialog())
                    fileContent = reader.ReadAll();

                var stats = CreateStatsContainer(fileContent);
                this.statsPage = new MainPage(this, stats);
            }
            catch
            {
                return;
            }

            closeTheFile.IsEnabled = true;
            mainFrame.Navigate(statsPage);
        }

        private StatsContainer CreateStatsContainer(string fileContent) // returns false, when file is incorrect
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
            mainFrame.Content = "";
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
                    SortedWordsGroupListMaker.SetDefaultValues();
                else
                {
                    try
                    {
                        (SortedWordsGroupListMaker.MinLenghtOfWords, SortedWordsGroupListMaker.MinAppearsTimesOfWord)
                            = newValues.Value;
                    }
                    catch
                    {
                        continue;
                    }
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
                {
                    string message = "Settings will be changed after reloading the file. Do you want reload now?";
                    var result = MessageBox.Show(this, message, "Question", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                        this.statsPage.ReloadFile();
                }                
                break;
            }
        }

        private WordsSettings CreateNewSettingsWindow()
        {
            var window = new WordsSettings()
            {
                Owner = this
            };

            window.minLenght.Text = SortedWordsGroupListMaker.MinLenghtOfWords.ToString();
            window.minAppearsTimes.Text = SortedWordsGroupListMaker.MinAppearsTimesOfWord.ToString();

            return window;
        }

        private void LinkToDataDownloadingPage_Click(object sender, RoutedEventArgs e) 
            => System.Diagnostics.Process.Start("https://www.facebook.com/settings?tab=your_facebook_information");

        private void OpenInstructions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
