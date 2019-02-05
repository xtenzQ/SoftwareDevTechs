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

        public ObservableCollection<ReportViewModel> Reports { get; set; }
        public ObservableCollection<ArticleViewModel> Articles { get; set; }

        public ResearcherViewModel()
        {
            _researcher = new Researcher();
            //TODO: Сделать FullName
        }

        public ResearcherViewModel(Researcher researcher)
        {
            _researcher = researcher;
        }

        public IEnumerable<string> AcademicDegrees => new[]
        {
            "Без степени", "Кандидат наук", "Доктор наук"
        };

        public Researcher ToResearcher()
        {
            return _researcher;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}