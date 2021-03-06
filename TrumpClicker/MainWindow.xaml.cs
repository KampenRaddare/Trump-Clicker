﻿using System;
using System.IO;
using System.Security;
using System.Windows;
using System.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace TrumpClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game Game = new Game();
        Save Save = new Save();
        SoundPlayer Click;
        System.Timers.Timer Timer;

        public MainWindow()
        {
            #region SETUP
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker");

            // Create appdata file and metadata file if they do not exist.
            if (!File.Exists(appData)) {
                Directory.CreateDirectory(appData);
                try
                {
                    string permissionTest = Path.Combine(appData, "permissiontest.txt");
                    File.WriteAllText(permissionTest,"ayy lmao");
                    File.Delete(permissionTest);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("For whatever reason, we do not have access to your AppData folder. \nPlease unristrict access or you can not use this program.");
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Trump Clicker"));
                }
                catch (SecurityException)
                {
                    MessageBox.Show("For whatever reason, you do not have access to your AppData folder. It is probably restricted by your system administrator.");
                }
            }
            #endregion
            InitializeComponent();

            // Load the last save
            Game.NumberOfClicks = Save.ReadSaveData();
            ClicksNumber.Content = Game.NumberOfClicks;
        }

        /// <summary>
        /// Handles the clicking
        /// of Trump's face.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Click = new SoundPlayer(Properties.Resources.Click);
            Click.Play();

            Game.NumberOfClicks++;

            // Setting UpTrump on click
            UpArrow.Source = new BitmapImage(new Uri(@"\Assets\UpArrow.png", UriKind.Relative));
            ClicksNumber.Content = Game.NumberOfClicks;
        }

        private void Window_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Timer = new System.Timers.Timer();
            Timer.Interval += 100;
            Timer.Elapsed += ReEnableForm;
            Timer.Start();

            IsEnabled = false;

            // Deselecting UpTrump on click finish
            UpArrow.Source = new BitmapImage(new Uri(@"\Assets\Blank.bmp", UriKind.Relative));
        }

        /// <summary>
        /// Restarts the save file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, RoutedEventArgs e) {
            Game.NumberOfClicks = 0;
            Save.WriteSaveData(Game.NumberOfClicks);
            ClicksNumber.Content = Game.NumberOfClicks;
        }

        private void ReEnableForm(object source, System.Timers.ElapsedEventArgs e)
        {
            // Allows updating of UI Elements from a different thread
            this.Dispatcher.Invoke((Action)(() =>
            {
                IsEnabled = true;
            }));
            Timer.Dispose();
        }

        /// <summary>
        /// Saves when the window
        /// closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e) {
            Save.WriteSaveData(Game.NumberOfClicks);
        }
    }
}
