namespace LinqFish.Windows.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClausalItem : NotifyPropertyChanged
    {
        private string m_Clause;
        private BigramItem[] m_Bigrams;

        public ClausalItem()
        {
        }

        public ClausalItem(string clause, Tuple<string, string>[] bigrams)
        {
            this.Clause = clause;
            this.SetBigrams(bigrams);
        }

        public string Clause
        {
            get
            {
                return m_Clause;
            }
            set
            {
                m_Clause = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public BigramItem[] Bigrams
        {
            get
            {
                return m_Bigrams;
            }
            set
            {
                m_Bigrams = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public void SetBigrams(Tuple<string, string>[] bigrams)
        {
            this.Bigrams =
                bigrams.Aggregate(
                    new List<BigramItem>(),
                    (list, tup) =>
                    {
                        list.Add(new BigramItem(tup));

                        return list;
                    })
                    .ToArray();
        }

        public override string ToString() => this.Clause;

        public string ToStringDetail() => 
            $"{this.Clause}\r\n{Bigrams.Aggregate(string.Empty, (str, bigram) => $"Bigram: {bigram.Item1} {bigram.Item2}\r\n")}";
    }
}
