using System;
using System.IO;
using System.Security;
using System.Windows;

namespace TrumpClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game Main;

        public MainWindow()
        {
            // Create appdata folder
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");

            // Create appdata file if it does not exist.
            if (!File.Exists(appData)) {
                Directory.CreateDirectory(appData);
                try {
                    using (StreamWriter sw = File.CreateText(Path.Combine(appData, "metadata" + ".txt"))) {
                        sw.WriteLine(0);
                    }
                } catch (UnauthorizedAccessException) {
                    MessageBox.Show("For whatever reason, we do not have access to your AppData folder. \nPlease unristrict access or you can not use this program.");
                } catch (DirectoryNotFoundException) {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker"));
                } catch (SecurityException) {
                    MessageBox.Show("For whatever reason, you do not have access to your AppData folder. It is probably restricted by your system administrator.");
                }
            }

            InitializeComponent();
            Main = new Game();
        }

        /// <summary>
        /// Handles the clicking
        /// of Trump's face and
        /// displays it in a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            
        }

        /// <summary>
        /// Restarts the current save file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// Chooses a save file to
        /// save the current game too.
        /// Only THREE max!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseSaveButton_Click(object sender, RoutedEventArgs e) {
            
        }

        /// <summary>
        /// Turns autosave on
        /// and off depending
        /// on if checked or
        /// not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveContextMenu_Checked(object sender, RoutedEventArgs e) {
            AutoSave();
        }

        private void AutoSave() {
            // . . .
        }

        /// <summary>
        /// Saves when the window
        /// closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e) {
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");
            string metaData = Path.Combine(appData, "metadata.txt");
            string[] file = null;

            try {
                file = File.ReadAllLines(metaData);
            } catch (Exception) {
                MessageBox.Show("A saving error has occured . . .", "Fatal Error");
            }

            file[0] = Convert.ToString(Main.NumberOfClicks);

            try {
                File.WriteAllLines(metaData, file);
            } catch (ArgumentNullException) {
                MessageBox.Show("A saving error has occured . . .", "Fatal Error");
            }
        }
    }
}
