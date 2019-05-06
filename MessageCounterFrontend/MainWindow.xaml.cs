using System;
using System.Windows;
using System.Windows.Controls;
using MessageCounterFrontend.InterfaceBackend;
using MessageCounterFrontend.SettingsWindows;

namespace MessageCounterFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MessageCounterBackend.StatsContainer statsContainer;
        private WrapPanel MainWrapPanel
        {
            get => scrollViewer.Content as WrapPanel;
            set => scrollViewer.Content = value;
        }

        public MainWindow()
        {
            InitializeComponent();

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string fileContent = new ReadFile(args[1]).Read();

                if (false == CreateStatsContainer(fileContent))
                    return;

                UpdateMainPanel();
                ChangeStatesOfCheckBoxes();
                closeTheFile.IsEnabled = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) => Close();

        private void SingleFile_Click(object sender, RoutedEventArgs e)
        {
            string fileContent;
            try
            {
                fileContent = new ReadFile().Read();
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
                ChangeStatesOfCheckBoxes();

            closeTheFile.IsEnabled = true;
        }

        private bool CreateStatsContainer(string fileContent) // returns false, when file is incorrect
        {
            try
            {
                statsContainer = new MessageCounterBackend.StatsContainer(fileContent);
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
                = WrapPanelMaker.IncludeMessages = false;

            checkBoxPeople.IsChecked 
                = checkBoxDays.IsChecked 
                = checkBoxWords.IsChecked = false;
        }

        private void CheckBoxPeople_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.PeopleContainer == null)
                statsContainer.MakePeopleContainer();

            WrapPanelMaker.IncludePeople = true;
            UpdateMainPanel();
            ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxDays_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.DaysContainer == null)
                statsContainer.MakeDaysContainer();

            WrapPanelMaker.IncludeDays = true;
            UpdateMainPanel();
            ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxWords_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.MessagesContainer == null)
                statsContainer.MakeMessagesContainer();

            WrapPanelMaker.IncludeMessages = true;
            UpdateMainPanel();
            ChangeStatesOfCheckBoxes();
        }

        private void UpdateMainPanel()
        {
            MainWrapPanel = WrapPanelMaker.MakeStatsWrapPanel(statsContainer);
            UpdateLayout();
        }

        private void ChangeStatesOfCheckBoxes()
        {
            checkBoxPeople.IsEnabled = !checkBoxPeople.IsEnabled;
            checkBoxDays.IsEnabled = !checkBoxDays.IsEnabled;
            checkBoxWords.IsEnabled = !checkBoxWords.IsEnabled;
        }

        private void CheckBoxPeople_Unchecked(object sender, RoutedEventArgs e)
        {
            WrapPanelMaker.IncludePeople = false;
            UpdateMainPanel();
        }

        private void CheckBoxDays_Unchecked(object sender, RoutedEventArgs e)
        {
            WrapPanelMaker.IncludeDays = false;
            UpdateMainPanel();
        }

        private void CheckBoxWords_Unchecked(object sender, RoutedEventArgs e)
        {
            WrapPanelMaker.IncludeMessages = false;
            UpdateMainPanel();
        }

        private void CloseTheFile_Click(object sender, RoutedEventArgs e)
        {
            closeTheFile.IsEnabled = false;
            ChangeStatesOfCheckBoxes();
            ResetStatesOfVariables();
            statsContainer = null;
            UpdateMainPanel();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new WordsSettings()
            {
                Owner = this
            };
            window.ShowDialog();

            if (false == window.DialogResult)
                return;

            var newValues = window.NewValues;

        }
    }
}
