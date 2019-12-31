using System.Windows;
using System.Windows.Controls;
using MessageCounterFrontend.MainWindowOperations;
using MessageCounterFrontend.Pages;
using MessageCounterFrontend.Windows.InfoWindows;

namespace MessageCounterFrontend.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Exiting { get; private set; }
        private bool HandledClosing { get; set; }

        private MainPage _statsPage;

        private bool IsAnyFileOpened => this._statsPage != null;
        private readonly bool _startedDirectlyWithPage;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string pathToFile) : this()
        {
            var opener = new FileOpener(pathToFile);
            OpenStatsPage(opener);
        }

        public MainWindow(Page page) : this()
        {
            this._startedDirectlyWithPage = true;
            mainFrame.Navigate(page);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var opener = new FileOpener();
                OpenStatsPage(opener);
            }
            catch { }
        }

        private void OpenStatsPage(FileOpener opener)
        {
            this._statsPage = opener.StatsPage;
            mainFrame.Navigate(_statsPage);
            closeTheFile.IsEnabled = true;
        }

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
                var page = this._statsPage.Reload((Page)mainFrame.Content);
                if (page != null)
                    mainFrame.Navigate(page);
            }
        }

        private void CloseTheFile_Click(object sender, RoutedEventArgs e)
        {
            this.HandledClosing = true;
            Close();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_startedDirectlyWithPage)
                Close();

            mainFrame.Navigate(_statsPage);
        }

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
            homeButton.Visibility = mainFrame.Content is MainPage ? Visibility.Hidden : Visibility.Visible;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (false == this.HandledClosing)
                this.Exiting = true;
        }
    }
}
