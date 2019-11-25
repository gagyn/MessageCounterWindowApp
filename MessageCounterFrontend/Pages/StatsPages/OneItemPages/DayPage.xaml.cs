using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using MessageCounterBackend.Containers;
using MessageCounterBackend.Containers.StatsClasses;
using MessageCounterBackend.Containers.StatsClasses.DateNameSpace;
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

            var messages = day.MessagesContainer.Messages.Select(x =>
            {
                var p = new Person(x.sender_name, day.MessagesContainer);
                return new MessageStrings(p, x.content, new Date(x.timestamp_ms).DateTime);
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
