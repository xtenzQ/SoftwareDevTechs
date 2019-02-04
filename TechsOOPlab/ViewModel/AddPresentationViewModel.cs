using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class AddPresentationViewModel : INotifyPropertyChanged
    {
        private Presentation _selectedPresentation;
        public ObservableCollection<Presentation> Presentations { get; set; }

        public Presentation SelectedPresentation
        {
            get => _selectedPresentation;
            set
            {
                if (Equals(value, _selectedPresentation)) return;
                _selectedPresentation = value;
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