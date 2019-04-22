using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageCounterFrontend.InterfaceBackend;
using System.Threading;

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
            get
            {
                return scrollViewer.Content as WrapPanel;
            }

            set
            {
                scrollViewer.Content = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            MainWrapPanel = new WrapPanel();

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string fileContent = new ReadFile(args[1]).Read();

                if (false == CreateStatsContainer(fileContent))
                    return;

                
                MainWrapPanel.Children.Add(NewWrapPanelMaker.PrepareStatsToString(statsContainer));
                ChangeStatesOfCheckBoxes();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CloseWindows_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void SingleFile_Click(object sender, RoutedEventArgs e)
        {
            MainWrapPanel.Children.Clear();

            NewWrapPanelMaker.IncludePeople = NewWrapPanelMaker.IncludeDays
                = NewWrapPanelMaker.IncludeMessages = false;

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
            
            MainWrapPanel.Children.Add(NewWrapPanelMaker.PrepareStatsToString(statsContainer));

            checkBoxPeople.IsChecked = checkBoxDays.IsChecked = checkBoxWords.IsChecked = false;

            if (false == checkBoxPeople.IsEnabled)
                ChangeStatesOfCheckBoxes();
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

        private void CheckBoxPeople_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.peopleContainer == null)
                statsContainer.MakePeopleContainer();

            NewWrapPanelMaker.IncludePeople = true;
            UpdateMainPanel();
            ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxDays_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.daysContainer == null)
                statsContainer.MakeDaysContainer();

            NewWrapPanelMaker.IncludeDays = true;
            UpdateMainPanel();
            ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxWords_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.messagesContainer == null)
                statsContainer.MakeMessagesContainer();

            NewWrapPanelMaker.IncludeMessages = true;
            UpdateMainPanel();
            ChangeStatesOfCheckBoxes();
        }

        private void UpdateMainPanel() => MainWrapPanel = NewWrapPanelMaker.PrepareStatsToString(statsContainer);

        private void ChangeStatesOfCheckBoxes()
        {
            checkBoxPeople.IsEnabled = !checkBoxPeople.IsEnabled;
            checkBoxDays.IsEnabled = !checkBoxDays.IsEnabled;
            checkBoxWords.IsEnabled = !checkBoxWords.IsEnabled;
        }

        private void CheckBoxPeople_Unchecked(object sender, RoutedEventArgs e)
        {
            NewWrapPanelMaker.IncludePeople = false;
            UpdateMainPanel();
        }

        private void CheckBoxDays_Unchecked(object sender, RoutedEventArgs e)
        {
            NewWrapPanelMaker.IncludeDays = false;
            UpdateMainPanel();
        }

        private void CheckBoxWords_Unchecked(object sender, RoutedEventArgs e)
        {
            NewWrapPanelMaker.IncludeMessages = false;
            UpdateMainPanel();
        }
    }
}
