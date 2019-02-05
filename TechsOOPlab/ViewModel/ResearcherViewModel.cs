using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class ResearcherViewModel : INotifyPropertyChanged
    {
        private Researcher _researcher;

        // ФИО
        public string LastName
        {
            get => _researcher.LastName;
            set
            {
                if (value == _researcher.LastName) return;
                _researcher.LastName = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _researcher.FirstName;
            set
            {
                if (value == _researcher.FirstName) return;
                _researcher.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => _researcher.MiddleName;
            set
            {
                if (value == _researcher.MiddleName) return;
                _researcher.MiddleName = value;
                OnPropertyChanged();
            }
        }

        // Номер отдела
        public int DepartmentNumber
        {
            get => _researcher.DepartmentNumber;
            set
            {
                if (value == _researcher.DepartmentNumber) return;
                _researcher.DepartmentNumber = value;
                OnPropertyChanged();
            }
        }

        // Возраст
        public int Age
        {
            get => _researcher.Age;
            set
            {
                if (value == _researcher.Age) return;
                _researcher.Age = value;
                OnPropertyChanged();
            }
        }

        // Ученая степень
        public string AcademicDegree
        {
            get => _researcher.AcademicDegree;
            set
            {
                if (value == _researcher.AcademicDegree) return;
                _researcher.AcademicDegree = value;
                OnPropertyChanged();
            }
        }

        // Должность
        public string Position
        {
            get => _researcher.Position;
            set
            {
                if (value == _researcher.Position) return;
                _researcher.Position = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> AcademicDegrees => new[]
        {
            "Без степени", "Кандидат наук", "Доктор наук"
        };

        public ObservableCollection<ReportViewModel> Reports { get; set; }
        public ObservableCollection<ArticleViewModel> Articles { get; set; }
        public ObservableCollection<MonographViewModel> Monographs { get; set; }
        public ObservableCollection<PresentationViewModel> Presentations { get; set; }

        public ResearcherViewModel()
        {
            _researcher = new Researcher();
            // ?
            Reports = new ObservableCollection<ReportViewModel>();
            Articles = new ObservableCollection<ArticleViewModel>();
            Monographs = new ObservableCollection<MonographViewModel>();
            Presentations = new ObservableCollection<PresentationViewModel>();
        }

        public ResearcherViewModel(Researcher researcher)
        {
            _researcher = researcher;
        }
        
        public Researcher ToResearcher()
        {
            return _researcher;
        }

        public void AddArticle(ArticleViewModel article)
        {
            var newArticle = article.ToArticle();
            _researcher.Articles.Add(newArticle);
            ModelContext.Articles.Add(newArticle);
            Articles.Add(article);
        }

        public void AddMonograph(MonographViewModel monograph)
        {
            var newMonograph = monograph.ToMonograph();
            _researcher.Monographs.Add(newMonograph);
            ModelContext.Monographs.Add(newMonograph);
            Monographs.Add(monograph);
        }

        public void AddPresentation(PresentationViewModel presentation)
        {
            var newPresentation = presentation.ToPresentation();
            _researcher.Presentations.Add(newPresentation);
            ModelContext.Presentations.Add(newPresentation);
            Presentations.Add(presentation);
        }

        public void AddReport(ReportViewModel report)
        {
            var newReport = report.ToReport();
            _researcher.Reports.Add(newReport);
            ModelContext.Reports.Add(newReport);
            Reports.Add(report);
        }

        public void DeleteArticle(ArticleViewModel article)
        {
            var newArticle = article.ToArticle();
            _researcher.Articles.Remove(newArticle);
            ModelContext.Articles.Remove(newArticle);
            Articles.Remove(article);
        }

        public void DeleteMonograph(MonographViewModel monograph)
        {
            var newMonograph = monograph.ToMonograph();
            _researcher.Monographs.Remove(newMonograph);
            ModelContext.Monographs.Remove(newMonograph);
            Monographs.Remove(monograph);
        }

        public void DeletePresentation(PresentationViewModel presentation)
        {
            var newPresentation = presentation.ToPresentation();
            _researcher.Presentations.Remove(newPresentation);
            ModelContext.Presentations.Remove(newPresentation);
            Presentations.Remove(presentation);
        }

        public void DeleteReport(ReportViewModel report)
        {
            var newReport = report.ToReport();
            _researcher.Reports.Remove(newReport);
            ModelContext.Reports.Remove(newReport);
            Reports.Remove(report);
        }

        public ResearcherViewModel Clone()
        {
            var nRes = new Researcher
            {
                FirstName = _researcher.FirstName,
                LastName = _researcher.LastName,
                MiddleName = _researcher.MiddleName,
                DepartmentNumber = _researcher.DepartmentNumber,
                Age = _researcher.Age,
                AcademicDegree = _researcher.AcademicDegree,
                Position = _researcher.Position
            };
            return new ResearcherViewModel(nRes);
        }

        public void Update(ResearcherViewModel researcherViewModel)
        {
            _researcher.LastName = researcherViewModel.LastName;
            _researcher.FirstName = researcherViewModel.FirstName;
            _researcher.MiddleName = researcherViewModel.MiddleName;
            _researcher.DepartmentNumber = researcherViewModel.DepartmentNumber;
            _researcher.Age = researcherViewModel.Age;
            _researcher.AcademicDegree = researcherViewModel.AcademicDegree;
            _researcher.Position = researcherViewModel.Position;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}