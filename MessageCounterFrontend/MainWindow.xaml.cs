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
        MessageCounterBackend.StatsContainer statsContainer;

        public MainWindow()
        {
            InitializeComponent();
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
            wrapPanel.Children.Clear();

            TextBlockMaker.IncludePeople = TextBlockMaker.IncludeDays 
                = TextBlockMaker.IncludeMessages = false;

            string fileContent;
            try
            {
                fileContent = (new ReadFile()).Read();
            }
            catch
            {
                return;
            }

            try
            {
                statsContainer = new MessageCounterBackend.StatsContainer(fileContent);
            }
            catch
            {
                MessageBox.Show("The file is incorrect!");
                return;
            }
            
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));

            checkBoxPeople.IsChecked = checkBoxDays.IsChecked = checkBoxWords.IsChecked = false;

            if (false == checkBoxPeople.IsEnabled)
                ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxPeople_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.peopleContainer == null)
                statsContainer.MakePeopleContainer();

            TextBlockMaker.IncludePeople = true;
            wrapPanel.Children.Clear();
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));
            ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxDays_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.daysContainer == null)
                statsContainer.MakeDaysContainer();

            TextBlockMaker.IncludeDays = true;
            wrapPanel.Children.Clear();
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));
            ChangeStatesOfCheckBoxes();
        }

        private void CheckBoxWords_Checked(object sender, RoutedEventArgs e)
        {
            ChangeStatesOfCheckBoxes();
            if (statsContainer.messagesContainer == null)
                statsContainer.MakeMessagesContainer();

            TextBlockMaker.IncludeMessages = true;
            wrapPanel.Children.Clear();
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));
            ChangeStatesOfCheckBoxes();
        }

        private void ChangeStatesOfCheckBoxes()
        {
            checkBoxPeople.IsEnabled = !checkBoxPeople.IsEnabled;
            checkBoxDays.IsEnabled = !checkBoxDays.IsEnabled;
            checkBoxWords.IsEnabled = !checkBoxWords.IsEnabled;
        }

        private void CheckBoxPeople_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBlockMaker.IncludePeople = false;
            wrapPanel.Children.Clear();
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));
        }

        private void CheckBoxDays_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBlockMaker.IncludeDays = false;
            wrapPanel.Children.Clear();
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));
        }

        private void CheckBoxWords_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBlockMaker.IncludeMessages = false;
            wrapPanel.Children.Clear();
            wrapPanel.Children.Add(TextBlockMaker.PrepareStatsToString(statsContainer));
        }
    }
}
