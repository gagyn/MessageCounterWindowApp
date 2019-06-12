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
        public bool Exiting { get; private set; } = false;
        private bool HandledClosing { get; set; } = false;

        private MainPage statsPage;

        private bool IsAnyFileOpened { get => this.statsPage != null; }

        public MainWindow(string pathToFile)
        {
            InitializeComponent();

            var opener = new FileOpener(this, pathToFile);
            OpenStatsPageIfPossible(opener);
        }

        public void OpenFile_Click(object sender, RoutedEventArgs e) 
            => OpenStatsPageIfPossible(new FileOpener(this));
        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Exiting = true;
            HandledClosing = true;
            Close();
        }
        public void OpenWordsSettings_Click(object sender, RoutedEventArgs e) => new SettingsOpener(this);
        public void ReloadFileIfNeeded()
        {
            if (IsAnyFileOpened)
                statsPage.ReloadFile();
        }

        private void OpenStatsPageIfPossible(FileOpener opener)
        {
            if (opener.StatsPage != null)
            {
                this.statsPage = opener.StatsPage;
                mainFrame.Navigate(statsPage);
                closeTheFile.IsEnabled = true;
            }
        }

        private void CloseTheFile_Click(object sender, RoutedEventArgs e)
        {
            this.HandledClosing = true;
            Close();
        }

        private void LinkToDataDownloadingPage_Click(object sender, RoutedEventArgs e) 
            => System.Diagnostics.Process.Start(Instructions.LinkToDownloadSite);

        private void OpenInstructions_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.NavigationService.Content.GetType() != typeof(Instructions)) // doesn't allow to open a few the same pages with instructions
                mainFrame.Navigate(new Instructions());
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e) 
            => mainFrame.GoBack();

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.GoForward();

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (mainFrame.CanGoBack)
                returnButton.Visibility = Visibility.Visible;
            else
                returnButton.Visibility = Visibility.Hidden;

            if (mainFrame.CanGoForward)
                forwardButton.Visibility = Visibility.Visible;
            else
                forwardButton.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (false == this.HandledClosing)
                this.Exiting = true;
        }
    }
}
