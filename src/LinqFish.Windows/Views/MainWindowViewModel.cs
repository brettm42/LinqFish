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
        private string[] clauses;
        private Tuple<string, string>[] bigrams;

        public MainWindowViewModel()
        {
            
        }

        public string Input { get; set; }

        public string[] Clauses
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

        public 

        public GetBigrams(string input)
        {
            var clauses = LinqFish.Clauser.GetClauses(input).FirstOrDefault(c => c.Any());

            foreach (string clause in clauses)
            {
                Tuple<string, string>[] bigrams = LinqFish.Chunker.GetBigrams(clause);
            }
        }
    }
}
