using MessageCounterFrontend.InterfaceBackend.FileOperators;
using MessageCounterFrontend.MainWindowOperations;
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
using System.Windows.Shapes;

namespace MessageCounterFrontend.Windows
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private MainWindow MainWindow { get; }

        public StartWindow()
        {
            InitializeComponent();
            TryToReadSettingsFile();

            string path = TryToReadArgs();

            if (path != null)
                OpenMainWindow(path);
        }

        private void TryToReadSettingsFile()
        {
            try  // Reading settings file
            {
                using (var reader = new SettingsFileReader(SettingsFileReader.SettingsFilePath))
                    reader.ReadSettings();
            }
            catch { }
        }

        private string TryToReadArgs()
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
                return args[1];
            else
                return null;
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileD = new OpenFileDialog();

            if (openFileD.ShowDialog() == true) // get a file name and open mainWindow only if user selected a file (didn't cancel)
                OpenMainWindow(openFileD.FileName);
        }

        private void OpenMainWindow(string path)
        {
            var mainWin = new MainWindow(path);

            this.Visibility = Visibility.Collapsed;

            mainWin.ShowDialog();

            this.Visibility = Visibility.Visible;

            if (mainWin.Exiting)
                Close();
        }

        private void OpenSettingsButton_Click(object sender, RoutedEventArgs e)
            => new SettingsOpener(this);
    }
}
