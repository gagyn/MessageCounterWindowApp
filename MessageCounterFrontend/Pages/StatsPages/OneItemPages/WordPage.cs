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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageCounterBackend.Containers.StatsClasses;

namespace MessageCounterFrontend.Pages.StatsPages.OneItemPages
{
    /// <summary>
    /// Interaction logic for WordsPage.xaml
    /// </summary>
    public partial class WordPage : Page
    {
        public WordPage(Word word)
        {
            InitializeComponent();
        }
    }
}
