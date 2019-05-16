using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MessageCounterFrontend.SettingsWindows
{
    /// <summary>
    /// Interaction logic for WordsSettings.xaml
    /// </summary>
    public partial class WordsSettings : SettingsWindow
    {
        public (int minLenght, int minAppearsTimes)? NewValues { get; private set; }

        public WordsSettings() => InitializeComponent();

        protected override void SaveAndExitButton_Click(object sender, RoutedEventArgs e)
        {
            base.SaveAndExitButton_Click(sender, e);
            NewValues = (int.Parse(minLenght.Text), int.Parse(minAppearsTimes.Text));
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
