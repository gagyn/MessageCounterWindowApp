using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using MessageCounter.Services.WordsGrouper.Models;

namespace MessageCounterFrontend.Windows.SettingsWindows
{
    /// <summary>
    /// Interaction logic for WordsSettingsWindow.xaml
    /// </summary>
    public partial class WordsSettingsWindow : SettingsWindow
    {
        public WordsGrouperSettings? NewSettings { get; private set; }

        public WordsSettingsWindow(WordsGrouperSettings wordsSettings)
        {
            InitializeComponent();

            this.minLenght.Text = wordsSettings.MinLengthOfWords.ToString();
            this.minAppearsTimes.Text = wordsSettings.MinAppearsTimesOfWord.ToString();
        }

        protected override void SaveAndExitButton_Click(object sender, RoutedEventArgs e)
        {
            base.SaveAndExitButton_Click(sender, e);
            NewSettings = new WordsGrouperSettings(uint.Parse(minLenght.Text), uint.Parse(minAppearsTimes.Text));
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
                e.Handled = true;
        }
    }
}
