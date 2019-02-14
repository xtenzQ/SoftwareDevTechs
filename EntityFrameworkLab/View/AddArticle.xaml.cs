using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EntityFrameworkLab.ViewModel;

namespace EntityFrameworkLab.View
{
    /// <summary>
    /// Логика взаимодействия для AddArticle.xaml
    /// </summary>
    public partial class AddArticle : Window
    {
        public ArticleViewModel Article { get; }
        private readonly ArticleViewModel _model;

        private readonly bool _isEdit;

        private int _noOfErrorsOnScreen = 0;

        public AddArticle(bool isEdit, ArticleViewModel article)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && article == null)
                throw new ArgumentNullException(nameof(article), "Обязательно нужен исследователь");
            Article = article ?? new ArticleViewModel();
            _model = _isEdit ? Article.Clone() : Article;
            AddButton.Content = _isEdit ? "Сохранить" : "Добавить";
            this.Title = _isEdit ? "Изменить статью" : "Добавить статью";
            DataContext = Article;
            DatePicker.Value = DateTime.Now;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
            Console.WriteLine(_noOfErrorsOnScreen);
        }

        private void AddCustomer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void AddCustomer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isEdit)
            {
                // ModelContext.Researchers.Add();
            }
            else
            {
                Article.Update(_model);
            }
            DialogResult = true;
        }
    }
}
