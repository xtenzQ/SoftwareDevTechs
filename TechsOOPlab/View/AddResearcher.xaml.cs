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

        private bool _isEdit;

        public AddResearcher(bool isEdit, ResearcherViewModel researcher)
        {
            InitializeComponent();
            _isEdit = isEdit;
            if (isEdit && researcher == null)
                throw new ArgumentNullException(nameof(researcher), "Обязатльно нужен исследователь");
            Researcher = researcher ?? new ResearcherViewModel();
            DataContext = Researcher;
        }

        private void AddResearcherButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isEdit)
            {
                ModelContext.Researchers.Add(Researcher.ToResearcher());
            }
            DialogResult = true;
        }
    }
}
