using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MessageCounterBackend.Containers.StatsClasses;

namespace MessageCounterFrontend.Pages.StatsPages.OneItemPages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class PersonPage : ChoicePage
    {
        private Person Person { get; }

        public PersonPage(Person person)
        {
            InitializeComponent();

            this.Person = person;
        }

        protected override void Buttons_Clicks(object sender, RoutedEventArgs e)
        {
            Page page = null;

            switch (( e.Source as Button ).Name)
            {
                case nameof(daysB):
                    page = new DaysPage(this.Person.DaysWhenUserWrittenSomething);
                    break;
                case nameof(wordsB):
                    page = new WordsPage(this.Person.PersonMessages.SortedWords);
                    break;
            }

            if (page != null)
                NavigationService.Navigate(page);
        }
    }
}
