namespace LinqFish.Windows.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LinqFish;
    using LinqFish.Windows.Infrastructure;

    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private string m_Output;
        private ClausalItem[] m_Clauses;
        private ClausalItem m_Clause;
        private BigramItem[] m_Bigrams;
        private BigramItem m_Bigram;
        private TrigramItem[] m_Trigrams;
        private TrigramItem m_Trigram;

        public string Input { get; set; }

        public string Output
        {
            get
            {
                return m_Output;
            }
            private set
            {
                m_Output = value;
                this.OnNotifyPropertyChanged();
            }
        }
        
        public ClausalItem[] Clauses
        {
            get
            {
                return this.m_Clauses;
            }
            private set
            {
                this.m_Clauses = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public ClausalItem SelectedClause
        {
            get
            {
                return this.m_Clause;
            }
            set
            {
                this.m_Clause = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public BigramItem[] Bigrams => this.SelectedClause?.Bigrams;

        public BigramItem SelectedBigram
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

        public void GetBigrams()
        {
            var clauses = LinqFish.Clauser.GetClauses(this.Input).FirstOrDefault(c => c.Any());

            if (clauses != null)
            {
                this.Clauses = clauses.Aggregate(
                    new List<ClausalItem>(),
                    (list, str) =>
                    {
                        list.Add(
                            new ClausalItem(str.Trim(), LinqFish.Chunker.GetBigrams(str.Trim())));

                        return list;
                    })
                    .ToArray();
            }
        }

        public TrigramItem[] Trigrams => this.SelectedClause?.Trigrams;

        public TrigramItem SelectedTrigram
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

        public void GetTrigrams()
        {
            var clauses = LinqFish.Clauser.GetClauses(this.Input).FirstOrDefault(c => c.Any());

            if (clauses != null)
            {
                this.Clauses = clauses.Aggregate(
                    new List<ClausalItem>(),
                    (list, str) =>
                    {
                        list.Add(
                            new ClausalItem(str.Trim(), LinqFish.Chunker.GetTrigrams(str.Trim())));

                        return list;
                    })
                    .ToArray();
            }
        }

        public void GetNgrams()
        {
            var clauses = LinqFish.Clauser.GetClauses(this.Input).FirstOrDefault(c => c.Any());

            if (clauses != null)
            {
                this.Clauses = clauses.Aggregate(
                    new List<ClausalItem>(),
                    (list, str) =>
                    {
                        var cItem = new ClausalItem { Clause = str.Trim() };
                        cItem.SetBigrams(LinqFish.Chunker.GetBigrams(str.Trim()));
                        cItem.SetTrigrams(LinqFish.Chunker.GetTrigrams(str.Trim()));

                        list.Add(cItem);

                        return list;
                    })
                    .ToArray();
            }
        }

        public void GetWordCounts()
        {
            if (this.Clauses == null) return;

            List<Tuple<string, string>> bigrams = new List<Tuple<string, string>>();

            foreach (ClausalItem clause in this.Clauses)
            {
                bigrams.AddRange(clause.GetBigrams());
            }
            
            ArrayToStringConverter converter = new ArrayToStringConverter();
            this.Output = $"Word Counts:\r\n{converter.Convert(LinqFish.Calculator.GetWordCounts(bigrams), null, null, null).ToString()}\r\nWord Frequency:\r\n{converter.Convert(LinqFish.Calculator.GetInstanceDistribution(bigrams), null, null, null)}";
        }
    }
}
