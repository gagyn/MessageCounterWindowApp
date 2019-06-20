using System.Windows;

namespace MessageCounterFrontend.Windows.SettingsWindows
{
    public abstract class SettingsWindow : Window
    {
        protected virtual void CancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;
        protected virtual void SaveAndExitButton_Click(object sender, RoutedEventArgs e) => DialogResult = true;
        protected virtual void ResetToDefault_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
