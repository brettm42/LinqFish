namespace LinqFish.Windows.Infrastructure
{
    using System;

    public class BigramItem : NotifyPropertyChanged
    {
        private Tuple<string, string> m_Bigram;

        public BigramItem()
        {
        }

        public BigramItem(Tuple<string, string> bigram)
        {
            this.Bigram = bigram;
        }

        public Tuple<string, string> Bigram
        {
            get
            {
                return this.m_Bigram;
            }
            set
            {
                this.m_Bigram = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public string Item1 => this.Bigram.Item1;

        public string Item2 => this.Bigram.Item2;

        public override string ToString() =>
            $"{this.Bigram.Item1} {this.Bigram.Item2}";
    }
}
