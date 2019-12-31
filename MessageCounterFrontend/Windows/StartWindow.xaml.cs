using MessageCounterFrontend.InterfaceBackend.FileOperators;
using MessageCounterFrontend.MainWindowOperations;
using MessageCounterFrontend.Windows.InfoWindows;
using Microsoft.Win32;
using System;
using System.Windows;

namespace MessageCounterFrontend.Windows
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();

            var path = ReadArgs();

            if (path != null)
                OpenMainWindow(path);
        }
        private string ReadArgs()
        {
            var args = Environment.GetCommandLineArgs();
            return args.Length > 1 ? args[1] : null;
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == true) // get a file name and open mainWindow only if user selected a file (didn't cancel)
                OpenMainWindow(fileDialog.FileName);
        }

        private void OpenMainWindow(string path)
        {
            try
            {
                var mainWindow = new MainWindow(path);

                this.Visibility = Visibility.Collapsed;

                mainWindow.ShowDialog();

                this.Visibility = Visibility.Visible;

                if (mainWindow.Exiting)
                    Close();
            }
            catch
            {
                // ignored
            }
        }

        private void OpenSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var settingsOpener = new SettingsOpener(this);
            settingsOpener.OpenWordsGrouperSettings();
        }

        private void OpenInstructions_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow(new Instructions());

            this.Visibility = Visibility.Collapsed;

            window.ShowDialog();

            this.Visibility = Visibility.Visible;
        }
    }
}
