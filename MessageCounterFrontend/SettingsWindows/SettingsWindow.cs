using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessageCounterFrontend.SettingsWindows
{
    public abstract class SettingsWindow : Window
    {
        protected virtual void CancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        protected virtual void SaveAndExitButton_Click(object sender, RoutedEventArgs e) => DialogResult = true;

    }
}
