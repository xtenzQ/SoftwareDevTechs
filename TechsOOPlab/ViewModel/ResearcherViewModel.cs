using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TechsOOPlab.Annotations;
using TechsOOPlab.Commands;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class ResearcherViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Researcher _researcher;

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
            OnPropertyChanged(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           Researcher researcher = new Researcher();
                           .Insert(0, phone);
                           SelectedPhone = phone;
                       }));
            }
        }*/

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName) || (LastName.Length > 196))
                        {
                            error = "Длина Вашей фамлилии должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(LastName, @"^[а-яА-Я]+$"))
                        {
                            error = "Фамилия должна содержать только русские буквы!";
                        }
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName) || FirstName.Length > 196)
                        {
                            error = "Длина Вашего имени должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(FirstName, @"^[а-яА-Я]+$"))
                        {
                            error = "Имя должно содержать только русские буквы!";
                        }
                        break;
                    case "MiddleName":
                        if (string.IsNullOrEmpty(MiddleName) || MiddleName.Length > 196)
                        {
                            error = "Длина Вашего отчества должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(MiddleName, @"^[а-яА-Я]+$"))
                        {
                            error = "Отчество должно содержать только русские буквы!";
                        }
                        break;
                    case "DepartmentNumber":
                        if (DepartmentNumber  < 1 || DepartmentNumber > 1000)
                        {
                            error = "Номер отдела должен быть больше 1 и меньше 1000!";
                        }

                        break;
                    case "Age":
                        if (Age < 1 || Age > 130)
                        {
                            error = "Возраст должен быть больше 0 и меньше 130";
                        }

                        break;
                    case "AcademicDegree":
                        if (string.IsNullOrEmpty(AcademicDegree))
                        {
                            error = "Выберите степень!";
                        }

                        break;
                    case "Position":
                        if (string.IsNullOrEmpty(Position) || Position.Length > 100)
                        {
                            error = "Длина должности должна быть меньше 100 символов!";
                        }
                        else if (!Regex.IsMatch(Position, @"^[а-яА-Я]+$"))
                        {
                            error = "Должность должна содержать только русские буквы!";
                        }

                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}