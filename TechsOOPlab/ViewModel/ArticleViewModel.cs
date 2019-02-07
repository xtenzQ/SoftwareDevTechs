using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;
using TechsOOPlab.Model;

namespace TechsOOPlab.ViewModel
{
    public class ArticleViewModel : INotifyPropertyChanged
    {
        private readonly Article _article;

        // Название статьи
        public string Name
        {
            get => _article.Name;
            set
            {
                if (value == _article.Name) return;
                _article.Name = value;
                OnPropertyChanged();
            }
        }

        // Название журнала
        public string MagazineName
        {
            get => _article.MagazineName;
            set
            {
                if (value == _article.MagazineName) return;
                _article.MagazineName = value;
                OnPropertyChanged();
            }
        }

        // Год и месяц издания
        public DateTime ReleaseDate
        {
            get => _article.ReleaseDate;
            set
            {
                if (value.Equals(_article.ReleaseDate)) return;
                _article.ReleaseDate = value;
                OnPropertyChanged();
            }
        }

        public ArticleViewModel()
        {
            _article = new Article();
        }

        public ArticleViewModel(Article article)
        {
            _article = article;
        }

        public Article ToArticle()
        {
            return _article;
        }

        public ArticleViewModel Clone()
        {
            var nRes = new Article()
            {
                Name = _article.Name,
                MagazineName = _article.MagazineName,
                ReleaseDate = _article.ReleaseDate
            };
            return new ArticleViewModel(nRes);
        }

        public void Update(ArticleViewModel articleViewModel)
        {
            _article.Name = articleViewModel.Name;
            _article.MagazineName = articleViewModel.MagazineName;
            _article.ReleaseDate = articleViewModel.ReleaseDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}