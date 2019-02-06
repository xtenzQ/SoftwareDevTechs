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

        private bool _isEdit;

        public AddReport(bool isEdit, ReportViewModel report)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && report == null)
                throw new ArgumentNullException(nameof(report), "Обязатльно нужен исследователь");
            Report = report ?? new ReportViewModel();
            DataContext = Report;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isEdit)
            {
                // ModelContext.Researchers.Add();
            }
            DialogResult = true;
        }
    }
}
