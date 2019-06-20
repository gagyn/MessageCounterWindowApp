using System.Windows.Controls;
using MessageCounterBackend.Containers.StatsClasses;

namespace MessageCounterFrontend.Pages.StatsPages.OneItemPages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class PersonPage : Page
    {
        public PersonPage(Person person)
        {
            InitializeComponent();
        }
    }
}
