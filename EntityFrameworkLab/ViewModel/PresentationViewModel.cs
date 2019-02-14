using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntityFrameworkLab.Model;
using EntityFrameworkLab.Support;

namespace EntityFrameworkLab.ViewModel
{
    public class PresentationViewModel : NotifyUiBase, IDataErrorInfo
    {
        private readonly Presentation _presentation;

        // Название доклада
        public string Name
        {
            get => _presentation.Name;
            set
            {
                if (value == _presentation.Name) return;
                _presentation.Name = value;
                OnPropertyChanged();
            }
        }

        // Название конференции
        public string ConferenceName
        {
            get => _presentation.ConferenceName;
            set
            {
                if (value == _presentation.ConferenceName) return;
                _presentation.ConferenceName = value;
                OnPropertyChanged();
            }
        }

        // Дата выступления
        public DateTime PresentationDate
        {
            get => _presentation.PresentationDate;
            set
            {
                if (value.Equals(_presentation.PresentationDate)) return;
                _presentation.PresentationDate = value;
                OnPropertyChanged();
            }
        }

        public PresentationViewModel()
        {
            _presentation = new Presentation();
        }

        public PresentationViewModel(Presentation presentation)
        {
            _presentation = presentation;
        }

        public Presentation ToPresentation()
        {
            return _presentation;
        }

        public PresentationViewModel Clone()
        {
            var nRes = new Presentation()
            {
                Name = _presentation.Name,
                ConferenceName = _presentation.ConferenceName,
                PresentationDate = _presentation.PresentationDate
            };
            return new PresentationViewModel(nRes);
        }

        public void Update(PresentationViewModel presentationViewModel)
        {
            _presentation.Name = presentationViewModel.Name;
            _presentation.ConferenceName = presentationViewModel.ConferenceName;
            _presentation.PresentationDate = presentationViewModel.PresentationDate;
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
                            error = "Длина названия доклада должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(ConferenceName):
                        if (string.IsNullOrEmpty(ConferenceName) || (ConferenceName.Length > 196))
                        {
                            error = "Длина названия конференции должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(PresentationDate):
                        if (PresentationDate.Year < 1900 && PresentationDate > DateTime.Now)
                        {
                            error = "Год должен быть не меньше 1900 и не больше текущей даты!";
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