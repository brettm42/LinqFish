namespace LinqFish.Windows.Infrastructure
{
    using System;

    public class TrigramItem : NotifyPropertyChanged
    {
        private Tuple<string, string, string> m_Trigram;

        public TrigramItem()
        {
        }

        public TrigramItem(Tuple<string, string, string> trigram)
        {
            this.Trigram = trigram;
        }

        public Tuple<string, string, string> Trigram
        {
            get
            {
                return this.m_Trigram;
            }
            set
            {
                this.m_Trigram = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public string Item1 => this.m_Trigram.Item1;

        public string Item2 => this.m_Trigram.Item2;

        public string Item3 => this.m_Trigram.Item3;

        public override string ToString() =>
            $"{this.Trigram.Item1} {this.Trigram.Item2} {this.Trigram.Item3}";
    }
}
