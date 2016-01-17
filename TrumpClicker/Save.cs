using System;
using System.IO;
using System.Windows;

namespace TrumpClicker
{
    internal sealed class Save
    {

        /// <summary>
        /// Saves provided data to metadata
        /// </summary>
        public void WriteSaveData(int data)
        {
            try
            {
                File.WriteAllText(Meta.metaData, data.ToString());
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("A saving error has occured.", Meta.fatalError);
            }
        }

        /// <summary>
        /// Loads the last
        /// known save.
        /// </summary>
        /// <returns></returns>
        public int ReadSaveData()
        {
            try
            {
                return int.Parse(File.ReadAllText(Meta.metaData));
            }
            catch
            {
                MessageBox.Show("Save file is damaged.\nAll progress has been lost.", Meta.fatalError);
                return 0;
            }
        }
    }
}
