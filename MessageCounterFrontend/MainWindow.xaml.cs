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
            string fileContent;
            try
            {
                var readFile = new ReadFile();
                fileContent = readFile.Read();
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

            wrapPanel.Children.Add(new TextBlockMaker(statsContainer).GetTextBlock());
        }

        private void CheckBoxPeople_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBoxDays_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBoxWords_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
