using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class MonographViewModel : INotifyPropertyChanged
    {
        // Название монографии
        public string Name { get; set; }

        // ФИО соавтора
        public FullName CoauthorName { get; set; }

        // Год издания
        public DateTime ReleaseDate { get; set; }

        // Число страниц
        public int PageCount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}