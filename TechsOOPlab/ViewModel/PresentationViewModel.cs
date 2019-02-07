using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class PresentationViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}