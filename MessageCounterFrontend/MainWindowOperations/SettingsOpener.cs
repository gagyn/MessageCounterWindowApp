﻿using MessageCounterBackend.Containers.Helpers_classes;
using MessageCounterFrontend.InterfaceBackend.FileOperators;
using MessageCounterFrontend.SettingsWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessageCounterFrontend.MainWindowOperations
{
    class SettingsOpener
    {
        private readonly MainWindow window;

        public SettingsOpener(MainWindow window)
        {
            this.window = window;
            OpenWordsSettings();
        }

        private void OpenWordsSettings()
        {
            (int, int)? newValues;

            try
            {
                newValues = GetValues();
            }
            catch { return; }

            if (null == newValues)
                SorterWordsGroupListMaker.SetDefaultValues();
            else
                SetValues(newValues.Value);

            TryToSaveToFile();
            window.ReloadFileIfNeeded();
        }

        private (int, int)? GetValues()
        {
            var window = CreateNewSettingsWindow();

            if (false == window.ShowDialog())
                throw new Exception("CanceledSettingNewValues");

            return window.NewValues;
        }

        private WordsSettings CreateNewSettingsWindow()
        {
            var (minLenght, minAppears) =
                (SorterWordsGroupListMaker.MinLenghtOfWords,
                SorterWordsGroupListMaker.MinAppearsTimesOfWord);

            return new WordsSettings(minLenght, minAppears)
            {
                Owner = this.window
            };
        }

        private void SetValues((int, int) newValues)
        {
            (SorterWordsGroupListMaker.MinLenghtOfWords,
             SorterWordsGroupListMaker.MinAppearsTimesOfWord)
                = newValues;
        }

        private void TryToSaveToFile()
        {
            try
            {
                using (var writer = new SettingsFileWriter(SettingsFileWriter.SettingsFilePath))
                    writer.WriteSettings();
            }
            catch
            {
                MessageBox.Show("Problem with file. Settings hasn't been saved.");
            }
        }
    }
}
