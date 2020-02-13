using System.Windows;
using System.Windows.Controls;
using MessageCounter.Models;

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
            var page = ((Button)e.Source).Name switch
            {
                nameof(daysB) => (Page) new DaysPage(this.Person.DaysWhenPersonWroteAny),
                nameof(wordsB) => new WordsPage(this.Person.Messages),
                _ => null
            };

            if (page != null)
            {
                NavigationService.Navigate(page);
            }
        }
    }
}
