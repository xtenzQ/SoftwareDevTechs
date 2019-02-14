using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntityFrameworkLab.Properties;
using EntityFrameworkLab.Support;

namespace EntityFrameworkLab.ViewModel
{
    public class MainWindowViewModel : NotifyUiBase
    {
        private ResearcherViewModel _selectedResearcher;
        private ArticleViewModel _selectedArticle;
        private MonographViewModel _selectedMonograph;
        private PresentationViewModel _selectedPresentation;
        private ReportViewModel _selectedReport;

        private ObservableCollection<ResearcherViewModel> _researchers;
        private ObservableCollection<ArticleViewModel> _articles;
        private ObservableCollection<MonographViewModel> _monographs;
        private ObservableCollection<PresentationViewModel> _presentations;
        private ObservableCollection<ReportViewModel> _reports;

        public ObservableCollection<ResearcherViewModel> Researchers
        {
            get => _researchers;
            set
            {
                if (Equals(value, _researchers)) return;
                _researchers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ArticleViewModel> Articles
        {
            get => _articles;
            set
            {
                if (Equals(value, _articles)) return;
                _articles = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MonographViewModel> Monographs
        {
            get => _monographs;
            set
            {
                if (Equals(value, _monographs)) return;
                _monographs = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PresentationViewModel> Presentations
        {
            get => _presentations;
            set
            {
                if (Equals(value, _presentations)) return;
                _presentations = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReportViewModel> Reports
        {
            get => _reports;
            set
            {
                if (Equals(value, _reports)) return;
                _reports = value;
                OnPropertyChanged();
            }
        }

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
    }
}