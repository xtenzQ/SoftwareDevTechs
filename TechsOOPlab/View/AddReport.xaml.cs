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
    /// Логика взаимодействия для AddReport.xaml
    /// </summary>
    public partial class AddReport : Window
    {
        public ReportViewModel Report { get; }
        private readonly ReportViewModel _model;

        private readonly bool _isEdit;
        private int _noOfErrorsOnScreen = 0;

        public AddReport(bool isEdit, ReportViewModel report)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && report == null)
                throw new ArgumentNullException(nameof(report), "Обязатльно нужен исследователь");
            Report = report ?? new ReportViewModel();
            _model = _isEdit ? Report.Clone() : Report;
            DataContext = Report;
            AddButton.Content = _isEdit ? "Сохранить" : "Добавить";
            this.Title = _isEdit ? "Изменить научный отчёт" : "Добавить научный отчёт";
            ReleaseDateN.Value = DateTime.Now.Year;
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
                // ModelContext.Researchers.Add();
            }
            else
            {
                Report.Update(_model);
            }
            DialogResult = true;
        }
    }
}
