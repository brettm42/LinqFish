namespace LinqFish.Windows.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LinqFish;
    using LinqFish.Windows.Infrastructure;

    class MainWindowViewModel : NotifyPropertyChanged
    {
        private ClausalItem[] m_Clauses;
        private ClausalItem m_Clause;
        private BigramItem[] m_Bigrams;
        private BigramItem m_Bigram;

        public MainWindowViewModel()
        {
            
        }

        public string Input { get; set; }
        
        public ClausalItem[] Clauses
        {
            get
            {
                return clauses;
            }
            set
            {
                clauses = value;
                this.OnNotifyPropertyChanged();
            }
        }

        public ClausalItem SelectedClause
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
                return this.SelectedClause.Bigrams;
            }
        }

        public BigramItem SelectedBigram
        {
            get
            {
                return m_Bigram;
            }
            set
            {
                m_Bigram = value;
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
                            new ClausalItem(str, LinqFish.Chunker.GetBigrams(str)));

                        return list;
                    })
                    .ToArray();
            }
        }
    }
}
