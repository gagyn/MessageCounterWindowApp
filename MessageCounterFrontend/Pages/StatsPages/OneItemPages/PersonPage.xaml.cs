using System.Windows.Controls;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterFrontend.StatsPages.OneItemPages
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
