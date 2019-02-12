using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class MonographViewModel : INotifyPropertyChanged, IDataErrorInfo
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
        public int ReleaseDate
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
                            error = "Длина названия монографии должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(CoauthorLastName):
                        if (string.IsNullOrEmpty(CoauthorLastName) || (CoauthorLastName.Length > 196))
                        {
                            error = "Длина фамлилии должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(CoauthorLastName, @"^[а-яА-Я]+$"))
                        {
                            error = "Фамилия должна содержать только русские буквы!";
                        }
                        break;
                    case nameof(CoauthorFirstName):
                        if (string.IsNullOrEmpty(CoauthorFirstName) || CoauthorFirstName.Length > 196)
                        {
                            error = "Длина имени должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(CoauthorFirstName, @"^[а-яА-Я]+$"))
                        {
                            error = "Имя должно содержать только русские буквы!";
                        }
                        break;
                    case nameof(CoauthorMiddleName):
                        if (string.IsNullOrEmpty(CoauthorMiddleName) || CoauthorMiddleName.Length > 196)
                        {
                            error = "Длина Вашего отчества должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(CoauthorMiddleName, @"^[а-яА-Я]+$"))
                        {
                            error = "Отчество должно содержать только русские буквы!";
                        }
                        break;
                    case nameof(ReleaseDate):
                        if (ReleaseDate < 1900 && ReleaseDate > DateTime.Now.Year)
                        {
                            error = "Год должен быть не меньше 1900 и не больше текущей даты!";
                        }
                        break;
                    case nameof(PageCount):
                        if (PageCount < 1)
                        {
                            error = "Длина монографии должна быть не меньше 1!";
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