﻿using System;
using System.Collections.ObjectModel;
using EntityFrameworkLab.Model;
using EntityFrameworkLab.Support;

namespace EntityFrameworkLab.ViewModel
{
    public class ArticleViewModel : NotifyUiBase
    {
        private readonly Article _article;
        public ObservableCollection<Article> Articles { get; set; }

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
                            error = "Длина названия статьи должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(MagazineName):
                        if (string.IsNullOrEmpty(MagazineName) || MagazineName.Length > 196)
                        {
                            error = "Длина незвания журнала должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(ReleaseDate):
                        if (ReleaseDate.Year < 1900 && ReleaseDate > DateTime.Now)
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