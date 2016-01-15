using System.Windows;

namespace TrumpClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
