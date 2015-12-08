namespace LinqFish.Windows.Infrastructure
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// OnNotifyPropertyChanged event abstract class.
    /// </summary>
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event delegate for <see cref="ProgressChangedEventHandler"/>
        /// </summary>
        /// <param name="property">Name of property to raise <see cref="PropertyChanged"/> event for.</param>
        protected void OnNotifyPropertyChanged([CallerMemberName] string property = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
