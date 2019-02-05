using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechsOOPlab.Forms;
using TechsOOPlab.Model;
using TechsOOPlab.ViewModel;

namespace TechsOOPlab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // модель представления данных
        private MainWindowViewModel _model;

        public MainWindow()
        {
            InitializeComponent();
            // создали модель
            _model = new MainWindowViewModel {Researchers = new ObservableCollection<ResearcherViewModel>(ModelContext.Researchers.Select(r => new ResearcherViewModel(r)))};
            // связали с окном
            DataContext = _model;
            // 
            //AddResearcher();
        }

        private void AddResearcher(Researcher researcher)
        {
            // В хранилище
            ModelContext.Researchers.Add(researcher);
            // В отображаемой коллекции
            //_model.Researchers.Add(researcher);
        }

        private void AddResearcherButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddResearcher(false, null);
            if (addWindow.ShowDialog() ?? false)
            {
                //_model.Researchers = new ObservableCollection<ResearcherViewModel>(ModelContext.Researchers.Select(r => new ResearcherViewModel(r)));
                _model.Researchers.Add(addWindow.Researcher);
            }
           
        }

        private void EditResearcherButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddResearcher(true, _model.SelectedResearcher);
            if (addWindow.ShowDialog() ?? false)
            {

            }

        }

        private void DeleteResearcherButton_Click(object sender, RoutedEventArgs e)
        {
            if (_model.SelectedResearcher == null) return;
            var resVM = _model.SelectedResearcher;
            var res = resVM.ToResearcher();
            ModelContext.Researchers.Remove(res);
            _model.Researchers.Remove(resVM);
            _model.SelectedResearcher = null;

        }

        private void DeleteResearcher(Researcher researcher)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _model.SelectedResearcher = (ResearcherViewModel)e.AddedItems[0];
            }
        }
    }
}
