using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class AddMonographViewModel : INotifyPropertyChanged
    {
        private Monograph _selectedMonograph;
        public ObservableCollection<Monograph> Monographs { get; set; }

        public Monograph SelectedMonograph
        {
            get => _selectedMonograph;
            set
            {
                if (Equals(value, _selectedMonograph)) return;
                _selectedMonograph = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}