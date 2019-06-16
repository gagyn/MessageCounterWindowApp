using System.Windows.Controls;
using System.Windows.Navigation;

namespace MessageCounterFrontend.InfoWindows
{
    /// <summary>
    /// Interaction logic for Instructions.xaml
    /// </summary>
    public partial class Instructions : Page
    {
        public static readonly string LinkToDownloadSite = "https://www.facebook.com/settings?tab=your_facebook_information";

        public Instructions()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, System.Windows.RoutedEventArgs e) 
            => System.Diagnostics.Process.Start(LinkToDownloadSite);
    }
}
