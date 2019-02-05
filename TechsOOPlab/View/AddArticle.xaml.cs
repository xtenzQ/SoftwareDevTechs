using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechsOOPlab.Model;
using TechsOOPlab.ViewModel;

namespace TechsOOPlab.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddArticle.xaml
    /// </summary>
    public partial class AddArticle : Window
    {
        public ArticleViewModel Article { get; }

        private bool _isEdit;

        public AddArticle(bool isEdit, ArticleViewModel article)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && article == null)
                throw new ArgumentNullException(nameof(article), "Обязатльно нужен исследователь");
            Article = article ?? new ArticleViewModel();
            DataContext = Article;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isEdit)
            {
                ModelContext.Researchers.
            }
            DialogResult = true;
        }
    }
}
