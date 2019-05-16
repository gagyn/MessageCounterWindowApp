using MessageCounterBackend;
using MessageCounterFrontend.InterfaceBackend;
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

            ResetStatesOfVariables();
        }

        public void ReloadFile()
        {
            StatsContainer.ResetContainers();
            MakeNeededContainers();
            UpdateMainPanel();
        }

        private void ResetStatesOfVariables()
        {
            WrapPanelMaker.IncludePeople
                = WrapPanelMaker.IncludeDays
                = WrapPanelMaker.IncludeWords = false;

            checkBoxPeople.IsChecked
                = checkBoxDays.IsChecked
                = checkBoxWords.IsChecked = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            switch ((e.Source as CheckBox).Name)
            {
                case nameof(checkBoxPeople):
                    WrapPanelMaker.IncludePeople = !WrapPanelMaker.IncludePeople;
                    break;

                case nameof(checkBoxDays):
                    WrapPanelMaker.IncludeDays = !WrapPanelMaker.IncludeDays;
                    break;

                case nameof(checkBoxWords):
                    WrapPanelMaker.IncludeWords = !WrapPanelMaker.IncludeWords;
                    break;
            }
            MakeNeededContainers();
            UpdateMainPanel();
        }
        private void MakeNeededContainers()
        {
            if (WrapPanelMaker.IncludePeople)
                MakePeopleContainerIfNeeded();

            if (WrapPanelMaker.IncludeDays)
                MakeDaysContainerIfNeeded();

            if (WrapPanelMaker.IncludeWords)
                MakeWordsContainerIfNeeded();
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

        private void UpdateMainPanel()
        {
            MainWrapPanel = WrapPanelMaker.MakeStatsWrapPanel(StatsContainer);
            UpdateLayout();
        }
    }
}
