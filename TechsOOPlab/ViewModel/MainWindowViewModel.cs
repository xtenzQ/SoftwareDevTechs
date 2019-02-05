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
        private ArticleViewModel _selectedArticle;
        private MonographViewModel _selectedMonograph;
        private PresentationViewModel _selectedPresentation;
        private ReportViewModel _selectedReport;
        public ObservableCollection<ResearcherViewModel> Researchers { get; set; }
        public ObservableCollection<ArticleViewModel> Articles { get; set; }
        public ObservableCollection<MonographViewModel> Monographs { get; set; }
        public ObservableCollection<PresentationViewModel> Presentations { get; set; }
        public ObservableCollection<ReportViewModel> Reports { get; set; }

        public ResearcherViewModel SelectedResearcher
        {
            get => _selectedResearcher;
            set
            {
                if (Equals(value, _selectedResearcher)) return;
                _selectedResearcher = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ResearcherAddIsEnabled));
            }
        }

        public ArticleViewModel SelectedArticle
        {
            get => _selectedArticle;
            set
            {
                if (Equals(value, _selectedArticle)) return;
                _selectedArticle = value;
                OnPropertyChanged();
            }
        }

        public MonographViewModel SelectedMonograph
        {
            get => _selectedMonograph;
            set
            {
                if (Equals(value, _selectedMonograph)) return;
                _selectedMonograph = value;
                OnPropertyChanged();
            }
        }

        public PresentationViewModel SelectedPresentation
        {
            get => _selectedPresentation;
            set
            {
                if (Equals(value, _selectedPresentation)) return;
                _selectedPresentation = value;
                OnPropertyChanged();
            }
        }

        public ReportViewModel SelectedReport
        {
            get => _selectedReport;
            set
            {
                if (Equals(value, _selectedReport)) return;
                _selectedReport = value;
                OnPropertyChanged();
            }
        }

        public bool ResearcherAddIsEnabled => _selectedResearcher != null;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}