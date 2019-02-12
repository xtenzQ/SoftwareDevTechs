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
using TechsOOPlab.ViewModel;

namespace TechsOOPlab.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddMonograph.xaml
    /// </summary>
    public partial class AddMonograph : Window
    {
        public MonographViewModel Monograph { get; }
        private readonly MonographViewModel _model;

        private int _noOfErrorsOnScreen = 0;

        private readonly bool _isEdit;

        public AddMonograph(bool isEdit, MonographViewModel monograph)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && monograph == null)
                throw new ArgumentNullException(nameof(monograph), "Обязательно нужен исследователь");
            Monograph = monograph ?? new MonographViewModel();
            _model = _isEdit ? Monograph.Clone() : Monograph;
            DataContext = Monograph;
            AddButton.Content = _isEdit ? "Сохранить" : "Добавить";
            this.Title = _isEdit ? "Изменить монографию" : "Добавить монографию";
            ReleaseYearNUD.Value = DateTime.Now.Year;
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
                Monograph.Update(_model);
            }
            DialogResult = true;
        }
    }
}
