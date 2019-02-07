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

        private readonly bool _isEdit;

        public AddMonograph(bool isEdit, MonographViewModel monograph)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && monograph == null)
                throw new ArgumentNullException(nameof(monograph), "Обязатльно нужен исследователь");
            Monograph = monograph ?? new MonographViewModel();
            _model = _isEdit ? Monograph.Clone() : Monograph;
            DataContext = Monograph;
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
