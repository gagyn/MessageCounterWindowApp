using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MessageCounterBackend.Containers;
using MessageCounterBackend.Containers.StatsClasses;
using MessageCounterFrontend.Pages.StatsPages.StringsForPages;

namespace MessageCounterFrontend.Pages.StatsPages
{
    /// <summary>
    /// Interaction logic for WordsPage.xaml
    /// </summary>
    public partial class WordsPage : Page
    {
        private List<Word> Words { get; }
        private ICollectionView LcvWordStrings
            => new ListCollectionView(GetWordStrings());
        public WordsPage(List<Word> words)
        {
            InitializeComponent();

            this.Words = words;
            this.dataGrid.ItemsSource = LcvWordStrings;
        }

        private List<WordStrings> GetWordStrings() 
            => this.Words.Select(x => new WordStrings(x)).ToList();

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var wordStrings = dataGrid.SelectedItem as WordStrings;
            var word = wordStrings.Word;

            // TODO: 
            //NavigationService.Navigate(new WordPage(word));
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
            {
                if (e.Column.SortMemberPath == nameof(Word.Text))
                    e.Column.SortDirection = ListSortDirection.Descending;
                else
                    e.Column.SortDirection = ListSortDirection.Ascending;
            }
            e.Handled = false;
        }
    }
}
