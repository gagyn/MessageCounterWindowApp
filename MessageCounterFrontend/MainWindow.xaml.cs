using System;
using System.Windows;
using System.Windows.Controls;
using MessageCounterBackend;
using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterFrontend.InterfaceBackend;
using MessageCounterFrontend.SettingsWindows;
using MessageCounterFrontend.InterfaceBackend.FileOperators;

namespace MessageCounterFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StatsContainer statsContainer;
        private WrapPanel MainWrapPanel
        {
            get => scrollViewer.Content as WrapPanel;
            set => scrollViewer.Content = value;
        }
        private bool IsAnyFileOpened { get => statsContainer != null; }

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                using (var reader = new SettingsFileReader(SettingsFileReader.SettingsFilePath))
                    reader.ReadSettings();
            }
            catch { }

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string fileContent;

                using (var reader = new FileReaderWithDialog(args[1]))
                    fileContent = reader.ReadAll();

                if (false == CreateStatsContainer(fileContent))
                    return;

                UpdateMainPanel();
                ChangeEnableStatesOfCheckBoxes();
                closeTheFile.IsEnabled = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) => Close();

        private void SingleFile_Click(object sender, RoutedEventArgs e)
        {
            string fileContent;
            try
            {
                using (var reader = new FileReaderWithDialog())
                    fileContent = reader.ReadAll();
            }
            catch
            {
                return;
            }

            if (false == CreateStatsContainer(fileContent))
                return;

            ResetStatesOfVariables();
            UpdateMainPanel();

            if (false == checkBoxPeople.IsEnabled)
                ChangeEnableStatesOfCheckBoxes();

            closeTheFile.IsEnabled = true;
        }

        private bool CreateStatsContainer(string fileContent) // returns false, when file is incorrect
        {
            try
            {
                statsContainer = new StatsContainer(fileContent);
            }
            catch
            {
                MessageBox.Show("The file is incorrect!");
                return false;
            }
            return true;
        }

        private void ResetStatesOfVariables()
        {
            WrapPanelMaker.IncludePeople
                = WrapPanelMaker.IncludeDays
                = WrapPanelMaker.IncludeWords = false;

            checkBoxPeople.IsChecked 
                = checkBoxDays.IsChecked 
                = checkBoxWords.IsChecked = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {            
            switch ((e.Source as CheckBox).Name)
            {
                case nameof(checkBoxPeople):
                    if (e.RoutedEvent.Name == "Checked")
                        MakePeopleContainerIfNeeded();
                    WrapPanelMaker.IncludePeople = !WrapPanelMaker.IncludePeople;
                    break;

                case nameof(checkBoxDays):
                    if (e.RoutedEvent.Name == "Checked")
                        MakeDaysContainerIfNeeded();
                    WrapPanelMaker.IncludeDays = !WrapPanelMaker.IncludeDays;
                    break;

                case nameof(checkBoxWords):
                    if (e.RoutedEvent.Name == "Checked")
                        MakeWordsContainerIfNeeded();
                    WrapPanelMaker.IncludeWords = !WrapPanelMaker.IncludeWords;
                    break;
            }
            UpdateMainPanel();
        }

        private void MakePeopleContainerIfNeeded()
        {
            if (null == statsContainer.PeopleContainer)
                statsContainer.MakePeopleContainer();
        }

        private void MakeDaysContainerIfNeeded()
        {
            if (null == statsContainer.DaysContainer)
                statsContainer.MakeDaysContainer();
        }

        private void MakeWordsContainerIfNeeded()
        {
            if (null == statsContainer.WordsContainer)
                statsContainer.MakeWordsContainer();
        }

        private void UpdateMainPanel()
        {
            MainWrapPanel = WrapPanelMaker.MakeStatsWrapPanel(statsContainer);
            UpdateLayout();
        }

        private void ChangeEnableStatesOfCheckBoxes()
        {
            checkBoxPeople.IsEnabled = !checkBoxPeople.IsEnabled;
            checkBoxDays.IsEnabled = !checkBoxDays.IsEnabled;
            checkBoxWords.IsEnabled = !checkBoxWords.IsEnabled;
        }

        private void CloseTheFile_Click(object sender, RoutedEventArgs e)
        {
            closeTheFile.IsEnabled = false;
            ChangeEnableStatesOfCheckBoxes();
            ResetStatesOfVariables();
            statsContainer = null;
            UpdateMainPanel();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
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

                if (IsAnyFileOpened)
                {
                    string message = "Settings will be changed after reloading the file. Do you want reload now?";
                    var result = MessageBox.Show(this, message, "Question", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                        ReloadFile();
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

        private void ReloadFile()
        {
            ResetStatesOfVariables();
            statsContainer.ResetContainers();
            UpdateMainPanel();
        }

        private void LinkToDataDownloadingPage(object sender, RoutedEventArgs e) 
            => System.Diagnostics.Process.Start("https://www.facebook.com/settings?tab=your_facebook_information");
    }
}
