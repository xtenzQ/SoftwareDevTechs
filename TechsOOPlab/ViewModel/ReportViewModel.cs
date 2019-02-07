using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class ReportViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}