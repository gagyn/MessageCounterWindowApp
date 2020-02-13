using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MessageCounter.Models;
using MessageCounter.Services.WordsGrouper;
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
        public WordsPage(List<Message> messages)
        {
            InitializeComponent();

            var wordsGrouper = new WordsGrouperService(messages);
            this.Words = wordsGrouper.GroupWords().ToList();
            this.dataGrid.ItemsSource = LcvWordStrings;
        }

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

            //NavigationService.Navigate(new WordPage(word));
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.SortDirection == null)
            {
                e.Column.SortDirection = e.Column.SortMemberPath == nameof(Word.WordContent) 
                    ? ListSortDirection.Descending 
                    : ListSortDirection.Ascending;
            }
            e.Handled = false;
        }
    }
}
