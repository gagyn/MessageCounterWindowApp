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
using MessageCounterFrontend.MainWindowOperations;
using MessageCounterFrontend.StatsPages;

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

            mainFrame.Navigate(new StartPage(this));

            try  // Reading settings file
            {
                using (var reader = new SettingsFileReader(SettingsFileReader.SettingsFilePath))
                    reader.ReadSettings();
            }
            catch { }

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                var fileOpener = new FileOpener(this, args);
                OpenStatsPageIfNeeded(fileOpener);
            }
        }

        public void OpenFile_Click(object sender, RoutedEventArgs e) 
            => OpenStatsPageIfNeeded(new FileOpener(this));
        public void Exit_Click(object sender, RoutedEventArgs e) => Close();
        public void OpenWordsSettings_Click(object sender, RoutedEventArgs e) => new SettingsOpener(this);
        public void ReloadFileIfNeeded()
        {
            if (IsAnyFileOpened)
                statsPage.ReloadFile();
        }

        private void OpenStatsPageIfNeeded(FileOpener opener)
        {
            if (opener.StatsPage != null)
            {
                statsPage = opener.StatsPage;
                mainFrame.Navigate(statsPage);
                closeTheFile.IsEnabled = true;
            }
        }

        private void CloseTheFile_Click(object sender, RoutedEventArgs e)
        {
            closeTheFile.IsEnabled = false;

            while (mainFrame.CanGoBack)
                mainFrame.GoBack();
            
            statsPage = null;
        }

        private void LinkToDataDownloadingPage_Click(object sender, RoutedEventArgs e) 
            => System.Diagnostics.Process.Start(Instructions.LinkToDownloadSite);

        private void OpenInstructions_Click(object sender, RoutedEventArgs e) 
            => mainFrame.Navigate(new Instructions());

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.GoBack();

            if (false == mainFrame.CanGoBack)
                returnButton.Visibility = Visibility.Hidden;
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (mainFrame.CanGoBack)
                returnButton.Visibility = Visibility.Visible;
            else
                returnButton.Visibility = Visibility.Hidden;
        }
    }
}
