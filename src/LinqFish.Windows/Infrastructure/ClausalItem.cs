namespace LinqFish.Windows.Infrastructure
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ClausalItem : NotifyPropertyChanged
    {
        private string m_Clause;
        private BigramItem[] m_Bigrams;
        private TrigramItem[] m_Trigrams;

        public ClausalItem()
        {
        }

        public ClausalItem(string clause, Tuple<string, string>[] bigrams)
        {
            this.Clause = clause;
            this.SetBigrams(bigrams);
        }

        public ClausalItem(string clause, Tuple<string, string, string>[] trigrams)
        {
            this.Clause = clause;
            this.SetTrigrams(trigrams);
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

        public TrigramItem[] Trigrams
        {
            get
            {
                return m_Trigrams;
            }
            set
            {
                m_Trigrams = value;
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

        public void SetTrigrams(Tuple<string, string, string>[] trigrams)
        {
            this.Trigrams =
                trigrams.Aggregate(
                    new List<TrigramItem>(),
                    (list, tup) =>
                    {
                        list.Add(new TrigramItem(tup));

                        return list;
                    })
                    .ToArray();
        }

        public override string ToString() => this.Clause;

        public string ToStringDetail() => 
            $"{this.Clause}\r\n{this.Bigrams.Aggregate(string.Empty, (str, bigram) => $"Bigram: {bigram.Item1} {bigram.Item2}\r\n")}";
    }
}
