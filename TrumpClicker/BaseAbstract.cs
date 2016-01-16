namespace TrumpClicker {
    abstract class BaseAbstract {
        public int _NumberOfClicks = 43;

        public abstract void SaveToMeta();

        public int NumberOfClicks {
            get { return _NumberOfClicks; }
            set { value = _NumberOfClicks; }
        }
    }
}
