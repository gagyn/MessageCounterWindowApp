using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageCounterBackend.Containers.Helpers_classes;

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
