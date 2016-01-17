using System;
using System.IO;
using System.Windows;

namespace TrumpClicker
{
    class Save
    {
        private static readonly string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
        private static readonly string metaData = Path.Combine(appData, "metadata.txt");

        /// <summary>
        /// Saves provided data to metadata
        /// </summary>
        public void WriteSaveData(int data)
        {
            // Saving
            try
            {
                File.WriteAllText(metaData, data.ToString());
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("A saving error has occured . . .", "Fatal Error");
            }
        }

        /// <summary>
        /// Loads the last
        /// known save.
        /// </summary>
        /// <returns></returns>
        public int ReadSaveData()
        {
            // Loading save
            try
            {
                return int.Parse(File.ReadAllText(metaData));
            }
            catch
            {
                MessageBox.Show("Save file is damaged\nAll progress has been lost.", "Fatal Error");
                return 0;
            }
        }
    }
}