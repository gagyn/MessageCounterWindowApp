using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MessageCounterFrontend.InfoWindows
{
    /// <summary>
    /// Interaction logic for Instructions.xaml
    /// </summary>
    public partial class Instructions : Page
    {
        public Instructions()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) 
            => System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);

        private void ReturnButton_Click(object sender, System.Windows.RoutedEventArgs e)
            => NavigationService.GoBack();
    }
}
