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
        private Researcher _selectedResearcher;
        public ObservableCollection<Researcher> Researchers { get; set; }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    Researcher researcher = new Researcher();
                    Researchers.Insert(0, researcher);
                    MessageBox.Show("Сработало!");
                }));
            }
        }

        private RelayCommand _removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                       (_removeCommand = new RelayCommand(obj =>
                           {
                               if (obj is Researcher researcher)
                               {
                                   Researchers.Remove(researcher);
                               }
                           },
                           (obj) => Researchers.Count > 0));
            }
        }

        public Researcher SelectedResearcher
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