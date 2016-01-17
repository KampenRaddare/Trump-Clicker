using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace TrumpClicker
{
    class Save
    {

        /// <summary>
        /// Saves  provided data to metadata
        /// </summary>
        public void WriteSaveData(int data)
        {
            // Saving

            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
            string metaData = Path.Combine(appData, "metadata.txt");
            List<string> file = new List<string>();

            file.Add(data.ToString());

            try
            {
                File.WriteAllLines(metaData, file);
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
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
            int save;

            // Load save 
            try
            {
                save = int.Parse(File.ReadAllText(Path.Combine(appData, "metadata.txt")));
            }
            catch
            {
                MessageBox.Show("Save file is damaged\nAll progress has been lost.", "Fatal Error");
                save = 0;
            }
            return save;
        }
    }
}
