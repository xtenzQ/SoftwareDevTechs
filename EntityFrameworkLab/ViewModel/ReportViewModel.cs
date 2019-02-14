using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntityFrameworkLab.Model;
using EntityFrameworkLab.Support;

namespace EntityFrameworkLab.ViewModel
{
    public class ReportViewModel : NotifyUiBase, IDataErrorInfo
    {
        private readonly Report _report;

        // Название научного отчёта
        public string Name
        {
            get => _report.Name;
            set
            {
                if (value == _report.Name) return;
                _report.Name = value;
                OnPropertyChanged();
            }
        }

        // Регистрационный номер
        public int RegisterNumber
        {
            get => _report.RegisterNumber;
            set
            {
                if (value == _report.RegisterNumber) return;
                _report.RegisterNumber = value;
                OnPropertyChanged();
            }
        }

        // Год выпуска
        public int ReleaseYear
        {
            get => _report.ReleaseYear;
            set
            {
                if (value == _report.ReleaseYear) return;
                _report.ReleaseYear = value;
                OnPropertyChanged();
            }
        }

        // Число страниц
        public int PageCount
        {
            get => _report.PageCount;
            set
            {
                if (value == _report.PageCount) return;
                _report.PageCount = value;
                OnPropertyChanged();
            }
        }

        public ReportViewModel()
        {
            _report = new Report();
        }

        public ReportViewModel(Report report)
        {
            _report = report;
        }

        public Report ToReport()
        {
            return _report;
        }

        public ReportViewModel Clone()
        {
            var nRes = new Report()
            {
                Name = _report.Name,
                RegisterNumber = _report.RegisterNumber,
                ReleaseYear = _report.ReleaseYear,
                PageCount = _report.PageCount
            };
            return new ReportViewModel(nRes);
        }

        public void Update(ReportViewModel reportViewModel)
        {
            _report.Name = reportViewModel.Name;
            _report.RegisterNumber = reportViewModel.RegisterNumber;
            _report.ReleaseYear = reportViewModel.ReleaseYear;
            _report.PageCount = reportViewModel.PageCount;
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name) || (Name.Length > 196))
                        {
                            error = "Длина названия отчета должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(RegisterNumber):
                        if (RegisterNumber < 1 && RegisterNumber > 1000)
                        {
                            error = "Регистрационный номер должен лежать в интервале от 0 до 1000!";
                        }
                        break;
                    case nameof(ReleaseYear):
                        if (ReleaseYear < 1900 && ReleaseYear > DateTime.Now.Year)
                        {
                            error = "Год должен быть не меньше 1900 и не больше текущей даты!";
                        }
                        break;
                    case nameof(PageCount):
                        if (PageCount < 1)
                        {
                            error = "Длина научного отчета должна быть не меньше 1!";
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