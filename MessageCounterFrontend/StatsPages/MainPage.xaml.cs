using MessageCounterBackend;
using MessageCounterFrontend.InterfaceBackend;
using MessageCounterFrontend.StatsPage;
using MessageCounterFrontend.StatsPages.OneItemPages;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MessageCounterFrontend
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly Window mainWindow;

        private StatsContainer StatsContainer { get; set; }
        private WrapPanel MainWrapPanel
        {
            get => scrollViewer.Content as WrapPanel;
            set => scrollViewer.Content = value;
        }

        public MainPage(Window window, StatsContainer container)
        {
            this.mainWindow = window;
            this.StatsContainer = container;

            InitializeComponent();
        }

        public void ReloadFile()
        {
            StatsContainer.ResetContainers();
        }

        private void ResetStatesOfVariables()
        {
            throw new NotImplementedException();
        }

        private void Buttons_Clicks(object sender, RoutedEventArgs e)
        {
            switch ((e.Source as Button).Name)
            {
                case nameof(peopleB):
                    MakePeopleContainerIfNeeded();
                    NavigationService.Navigate(new PeoplePage(StatsContainer.PeopleContainer));
                    break;

                case nameof(daysB):
                    throw new NotImplementedException();
                    break;

                case nameof(WordsB):
                    throw new NotImplementedException();
                    break;
            }
        }

        private void MakePeopleContainerIfNeeded()
        {
            if (null == StatsContainer.PeopleContainer)
                StatsContainer.MakePeopleContainer();
        }

        private void MakeDaysContainerIfNeeded()
        {
            if (null == StatsContainer.DaysContainer)
                StatsContainer.MakeDaysContainer();
        }

        private void MakeWordsContainerIfNeeded()
        {
            if (null == StatsContainer.WordsContainer)
                StatsContainer.MakeWordsContainer();
        }
    }
}
