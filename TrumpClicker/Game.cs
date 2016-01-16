using System;
using System.IO;
using System.Windows;

namespace TrumpClicker
{
    class Game : BaseAbstract
    {

        /// <summary>
        /// Restarts game and
        /// resets metadata to
        /// zero.
        /// </summary>
        public override void SaveToMeta()
        {
            // Restarting

            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
            string metaData = Path.Combine(appData, "metadata.txt");
            string[] file = null;

            try
            {
                file = File.ReadAllLines(metaData);
            }
            catch (Exception)
            {
                MessageBox.Show("A saving error has occured . . .", "Fatal Error");
            }

            file[0] = Convert.ToString(0);

            try
            {
                File.WriteAllLines(metaData, file);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("A saving error has occured . . .", "Fatal Error");
            }
        }
    }
}
