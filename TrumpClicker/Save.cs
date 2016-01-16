using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;

namespace TrumpClicker
{
    class Save : BaseAbstract
    {

        /// <summary>
        /// Saves to metadata
        /// </summary>
        public override void SaveToMeta()
        {
            // Saving

            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
            string metaData = Path.Combine(appData, "metadata.txt");
            List<string> file = new List<string>();

            file.Add(this.NumberOfClicks.ToString());
            Debug.WriteLine(this.NumberOfClicks);

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
        public int LoadSave()
        {
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
            int save;

            // Load save
            using (StreamReader sr = new StreamReader(Path.Combine(appData, "metadata.txt")))
            {
                save = Convert.ToInt32(sr.ReadLine());
            }

            return save;
        }
    }
}
