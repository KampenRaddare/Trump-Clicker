/*
This class violates the
Single Responsibility Principle
but I don't give two shits. XD
*/

namespace TrumpClicker {
    class Game {

        internal int NumberOfClicks = 0;

        public Game(int numberOfClicks) {
            _NumberOfClicks = numberOfClicks;
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

    }
}
