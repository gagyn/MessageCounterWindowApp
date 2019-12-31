using MessageCounterFrontend.InterfaceBackend.FileOperators;
using MessageCounterFrontend.Windows.SettingsWindows;
using System.Windows;
using MessageCounter.Services.WordsGrouper.Models;

namespace MessageCounterFrontend.MainWindowOperations
{
    public class SettingsOpener
    {
        public bool IsValueChanged { get; private set; }

        private readonly Window _window;

        public SettingsOpener(Window window)
        {
            this._window = window;
        }

        public WordsGrouperSettings OpenWordsGrouperSettings()
        {
            var settingsReader = new SettingsFileReader();
            var oldWordsSettings = settingsReader.ReadSettings();
            var wordsSettingsWindow = new WordsSettingsWindow(oldWordsSettings) { Owner = _window };

            if (wordsSettingsWindow.ShowDialog() == false)
            {
                return oldWordsSettings;
            }

            IsValueChanged = true;
            SaveToFile(wordsSettingsWindow.NewSettings);
            return wordsSettingsWindow.NewSettings;
        }

        private void SaveToFile(WordsGrouperSettings wordsSettings)
        {
            var settingsWriter = new SettingsFileWriter();
            settingsWriter.WriteSettings(wordsSettings);
        }
    }
}
