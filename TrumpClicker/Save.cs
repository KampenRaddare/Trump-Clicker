using System;
using System.IO;
using System.Windows;

namespace TrumpClicker
{
    class Save : BaseAbstract
    {

        public override void SaveToMeta()
        {
            // Saving

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

            file[0] = Convert.ToString(this.NumberOfClicks);

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
