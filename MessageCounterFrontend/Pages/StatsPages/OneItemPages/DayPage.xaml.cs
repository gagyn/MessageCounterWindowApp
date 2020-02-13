using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using MessageCounter.Models;
using MessageCounter.Services.WordsGrouper;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;

namespace MessageCounterFrontend.Pages.StatsPages.OneItemPages
{
    /// <summary>
    /// Interaction logic for DayPage.xaml
    /// </summary>
    public partial class DayPage : Page
    {
        public DayPage(Day day)
        {
            InitializeComponent();

            var messagesList = day.Messages.ToList();
            var messagesCount = messagesList.Count();
            var wordsCount = new WordsGrouperService(messagesList).GroupWords().Count();

            var messages = day.Messages.Select(x =>
            {
                var p = new Person(x.AuthorName, messagesList, messagesCount, wordsCount);
                return new MessageStrings(p, x.Content, x.DateTime);
            });

            var list = new ListCollectionView(messages.ToList());
            this.dataGrid.ItemsSource = list;
        }

        private void DataGridCell_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            return;
        }
    }
}
