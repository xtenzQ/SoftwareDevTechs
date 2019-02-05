using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TechsOOPlab.Annotations;
using TechsOOPlab.Commands;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ResearcherViewModel _selectedResearcher;
        public ObservableCollection<ResearcherViewModel> Researchers { get; set; }

        public ResearcherViewModel SelectedResearcher
        {
            get => _selectedResearcher;
            set
            {
                if (Equals(value, _selectedResearcher)) return;
                _selectedResearcher = value;
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