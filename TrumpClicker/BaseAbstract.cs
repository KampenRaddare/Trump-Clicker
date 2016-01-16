namespace TrumpClicker {
    abstract class BaseAbstract {
        public int _NumberOfClicks = 0;

        public abstract void SaveToMeta();

        public int NumberOfClicks {
            get {
                _NumberOfClicks++;
                return _NumberOfClicks;
            }
            set { value = _NumberOfClicks; }
        }
    }
}
