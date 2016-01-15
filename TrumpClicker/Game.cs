/*
This class violates the
Single Responsibility Principle
but I don't give two shits. XD
*/

namespace TrumpClicker {
    class Game {

        private int _CurrentSaveFileVersion; // Only three saves allowed.
        private int _NumberOfClicks = 0;

        public Game(int currentSaveFileVersion) {
            
        }

        public void Save() {
            // . . .
        }

        public void Restart() {
            // . . .
        }

        public void RetrieveSave() {
            // . . .
        }

        public int CurrentSaveFileVersion {
            get { return _CurrentSaveFileVersion; }
            set { value = _CurrentSaveFileVersion; }
        }

        public int NumberOfClicks {
            get { return _NumberOfClicks; }
            set { value = _NumberOfClicks; }
        }
    }
}
