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

namespace MessageCounterFrontend.StatsPages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private MainWindow MainWindow { get; }

        public StartPage(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;

            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
            => this.MainWindow.OpenFile_Click(sender, e);

        private void OpenSettingsButton_Click(object sender, RoutedEventArgs e) 
            => MainWindow.OpenWordsSettings_Click(sender, e);
    }
}