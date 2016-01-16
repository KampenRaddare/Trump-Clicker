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
        Game Main = new Game();
        Save Save = new Save();

        public MainWindow()
        {
            // #SETUP
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");

            // Create appdata file if it does not exist.
            if (!File.Exists(appData)) {
                Directory.CreateDirectory(appData);
            }

            // #END_SETUP
            InitializeComponent();

            // Load the last save
            Main.NumberOfClicks = Save.LoadSave();
            ClicksNumber.Content = Main.NumberOfClicks;
        }

        /// <summary>
        /// Handles the clicking
        /// of Trump's face.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Main.NumberOfClicks++;
            Save.NumberOfClicks++;
            ClicksNumber.Content = Main.NumberOfClicks;
        }

        /// <summary>
        /// Restarts the save file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, RoutedEventArgs e) {
            Main.SaveToMeta();
            ClicksNumber.Content = Main.NumberOfClicks;
        }

        /// <summary>
        /// Saves when the window
        /// closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e) {
            Save.SaveToMeta();
        }
    }
}
