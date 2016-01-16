namespace TrumpClicker
{
    abstract class BaseAbstract
    {
        private int _NumberOfClicks;

        public abstract void SaveToMeta();

        public int NumberOfClicks
        {
            get
            {
                return this._NumberOfClicks;
            }
            set { this._NumberOfClicks = value; }
        }
    }
}
