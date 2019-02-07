using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class MonographViewModel : INotifyPropertyChanged
    {
        private readonly Monograph _monograph;

        // Название монографии
        public string Name
        {
            get => _monograph.Name;
            set
            {
                if (value == _monograph.Name) return;
                _monograph.Name = value;
                OnPropertyChanged();
            }
        }

        // ФИО соавтора
        public string CoauthorLastName
        {
            get => _monograph.CoauthorLastName;
            set
            {
                if (value == _monograph.CoauthorLastName) return;
                _monograph.CoauthorLastName = value;
                OnPropertyChanged();
            }
        }

        public string CoauthorFirstName
        {
            get => _monograph.CoauthorFirstName;
            set
            {
                if (value == _monograph.CoauthorFirstName) return;
                _monograph.CoauthorFirstName = value;
                OnPropertyChanged();
            }
        }

        public string CoauthorMiddleName
        {
            get => _monograph.CoauthorMiddleName;
            set
            {
                if (value == _monograph.CoauthorMiddleName) return;
                _monograph.CoauthorMiddleName = value;
                OnPropertyChanged();
            }
        }

        // Год издания
        public DateTime ReleaseDate
        {
            get => _monograph.ReleaseDate;
            set
            {
                if (value.Equals(_monograph.ReleaseDate)) return;
                _monograph.ReleaseDate = value;
                OnPropertyChanged();
            }
        }

        // Число страниц
        public int PageCount
        {
            get => _monograph.PageCount;
            set
            {
                if (value == _monograph.PageCount) return;
                _monograph.PageCount = value;
                OnPropertyChanged();
            }
        }

        public MonographViewModel()
        {
            _monograph = new Monograph();
        }

        public MonographViewModel(Monograph monograph)
        {
            _monograph = monograph;
        }

        public Monograph ToMonograph()
        {
            return _monograph;
        }

        public MonographViewModel Clone()
        {
            var nRes = new Monograph()
            {
                Name = _monograph.Name,
                CoauthorFirstName = _monograph.CoauthorFirstName,
                CoauthorLastName = _monograph.CoauthorLastName,
                CoauthorMiddleName = _monograph.CoauthorMiddleName,
                ReleaseDate = _monograph.ReleaseDate,
                PageCount = _monograph.PageCount,
            };
            return new MonographViewModel(nRes);
        }

        public void Update(MonographViewModel monographViewModel)
        {
            _monograph.Name = monographViewModel.Name;
            _monograph.CoauthorFirstName = monographViewModel.CoauthorFirstName;
            _monograph.CoauthorLastName = monographViewModel.CoauthorLastName;
            _monograph.CoauthorMiddleName = monographViewModel.CoauthorMiddleName;
            _monograph.ReleaseDate = monographViewModel.ReleaseDate;
            _monograph.PageCount = monographViewModel.PageCount;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}