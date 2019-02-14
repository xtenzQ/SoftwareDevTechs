using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntityFrameworkLab.Properties;

namespace EntityFrameworkLab.Support
{
    public class NotifyUiBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}