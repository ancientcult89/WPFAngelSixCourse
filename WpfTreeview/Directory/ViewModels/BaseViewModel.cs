using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeview.Directory.ViewModels
{
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>{};
    }
}
