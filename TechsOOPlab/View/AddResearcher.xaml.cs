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
    /// Логика взаимодействия для AddResearcher.xaml
    /// </summary>
    public partial class AddResearcher : Window
    {
        public ResearcherViewModel Researcher { get; }
        private readonly ResearcherViewModel _model;

        private readonly bool _isEdit;
        private int _noOfErrorsOnScreen = 0;

        public AddResearcher(bool isEdit, ResearcherViewModel researcher)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && researcher == null)
                throw new ArgumentNullException(nameof(researcher), "Обязательно нужен исследователь");
            Researcher = researcher ?? new ResearcherViewModel();
            _model = _isEdit ? Researcher.Clone() : Researcher;
            DataContext = _model;
            AddButton.Content = _isEdit ? "Сохранить" : "Добавить";
            this.Title = _isEdit ? "Изменить научного сотрудника" : "Добавить научного сотрудника";
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
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
                ModelContext.Researchers.Add(Researcher.ToResearcher());
            }
            else
            {
                Researcher.Update(_model);
            }
            DialogResult = true;
        }
    }
}
