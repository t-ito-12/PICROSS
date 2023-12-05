using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PICROSSCommon
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Declare the event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>The calling member's name will be used as the parameter.</remarks>
        protected void OnPropertyChanged ([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
