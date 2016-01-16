namespace TrumpClicker
{
    abstract class BaseAbstract
    {
        public int _NumberOfClicks = 0;

        public abstract void SaveToMeta();

        public int NumberOfClicks
        {
            get
            {
                this._NumberOfClicks++;
                return this._NumberOfClicks;
            }
            set { value = this._NumberOfClicks; }
        }
    }
}
