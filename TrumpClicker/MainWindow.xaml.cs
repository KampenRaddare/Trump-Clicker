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
            int save;

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

            // Load save
            using (StreamReader sr = new StreamReader(Path.Combine(appData, "metadata.txt"))) {
                save = Convert.ToInt32(sr.ReadLine());
            }

            InitializeComponent();
            Main = new Game(save);
        }

        /// <summary>
        /// Handles the clicking
        /// of Trump's face.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Main.NumberOfClicks += 1;
            ClicksNumber.Content = Main.NumberOfClicks;
            MessageBox.Show("WORK PLS");
        }

        /// <summary>
        /// Restarts the current save file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, RoutedEventArgs e) {

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
