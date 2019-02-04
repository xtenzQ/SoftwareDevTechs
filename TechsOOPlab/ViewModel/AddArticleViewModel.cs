using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class AddArticleViewModel : INotifyPropertyChanged
    {
        private Article _selectedArticle;
        public ObservableCollection<Article> Articles { get; set; }

        public Article SelectedArticle
        {
            get => _selectedArticle;
            set
            {
                if (Equals(value, _selectedArticle)) return;
                _selectedArticle = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}