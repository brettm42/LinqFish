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
        private ClausalItem[] m_Clauses;
        private ClausalItem m_Clause;
        private BigramItem[] m_Bigrams;
        private BigramItem m_Bigram;

        public string Input { get; set; }
        
        public ClausalItem[] Clauses
        {
            get
            {
                return this.m_Clauses;
            }
            set
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
                        list.Add(
                            new ClausalItem
                            {
                                this.Clause = str.Trim(),
                                this.Bigrams = LinqFish.Chunker.GetBigrams(str.Trim()),
                                this.Trigrams = LinqFish.Chunker.GetTrigrams(str.Trim()),
                            });

                        return list;
                    })
                    .ToArray();
            }
        }
    }
}
