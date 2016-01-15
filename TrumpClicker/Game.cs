/*
This class violates the
Single Responsibility Principle
but I don't give two shits. XD
*/

namespace TrumpClicker {
    class Game {

        private int _NumberOfClicks = 0;

        public void Save() {
            // . . .
        }

        public void Restart() {
            // . . .
        }

        public void RetrieveSave() {
            // . . .
        }

        public int NumberOfClicks {
            get { return _NumberOfClicks; }
            set { value = _NumberOfClicks; }
        }
    }
}
