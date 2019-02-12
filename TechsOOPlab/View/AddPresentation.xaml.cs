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
    /// Логика взаимодействия для AddPresentation.xaml
    /// </summary>
    public partial class AddPresentation : Window
    {
        public PresentationViewModel Presentation { get; }
        private readonly PresentationViewModel _model;

        private readonly bool _isEdit;

        private int _noOfErrorsOnScreen = 0;

        public AddPresentation(bool isEdit, PresentationViewModel presentation)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && presentation == null)
                throw new ArgumentNullException(nameof(presentation), "Обязательно нужен исследователь");
            Presentation = presentation ?? new PresentationViewModel();
            _model = _isEdit ? Presentation.Clone() : Presentation;
            DataContext = Presentation;
            AddButton.Content = _isEdit ? "Сохранить" : "Добавить";
            this.Title = _isEdit ? "Изменить доклад" : "Добавить доклад";
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
                Presentation.Update(_model);
            }
            DialogResult = true;
        }
    }
}
