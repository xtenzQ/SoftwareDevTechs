using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class AddReportViewModel : INotifyPropertyChanged
    {
        private Report _selectedReport;
        public ObservableCollection<Report> Reports { get; set; }

        public Report SelectedReport
        {
            get => _selectedReport;
            set
            {
                if (Equals(value, _selectedReport)) return;
                _selectedReport = value;
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