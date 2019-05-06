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
using System.Windows.Shapes;

namespace MessageCounterFrontend.SettingsWindows
{
    /// <summary>
    /// Interaction logic for WordsSettings.xaml
    /// </summary>
    public partial class WordsSettings : SettingsWindow
    {
        public (int minLenght, int minAppearsTimes) NewValues { get; private set; }

        public WordsSettings() => InitializeComponent();

        protected override void SaveAndExitButton_Click(object sender, RoutedEventArgs e)
        {
            base.SaveAndExitButton_Click(sender, e);
            NewValues = (int.Parse(minLenght.Text), int.Parse(minAppearsTimes.Text));
        }
    }
}
