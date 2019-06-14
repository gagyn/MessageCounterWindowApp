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
using MessageCounterFrontend.StatsPage;

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

        private void OpenFile_Click(object sender, RoutedEventArgs e) 
            => OpenStatsPageIfPossible(new FileOpener(this));

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Exiting = true;
            HandledClosing = true;
            Close();
        }

        private void OpenWordsSettings_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsOpener(this);

            if (settings.ChangedValues && this.IsAnyFileOpened)
            {
                var page = this.statsPage.Reload((Page)mainFrame.Content);
                if (page != null)
                    mainFrame.Navigate(page);
            }
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

        private void HomeButton_Click(object sender, RoutedEventArgs e) => CloseTheFile_Click(sender, e);

        private void LinkToDataDownloadingPage_Click(object sender, RoutedEventArgs e) 
            => System.Diagnostics.Process.Start(Instructions.LinkToDownloadSite);

        private void OpenInstructions_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content.GetType() != typeof(Instructions)) // doesn't allow to open a few the same pages with instructions
                mainFrame.Navigate(new Instructions());
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e) 
            => mainFrame.GoBack();

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.GoForward();

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            returnButton.Visibility = mainFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
            forwardButton.Visibility = mainFrame.CanGoForward ? Visibility.Visible : Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (false == this.HandledClosing)
                this.Exiting = true;
        }
    }
}
