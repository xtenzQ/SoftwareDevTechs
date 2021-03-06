﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EntityFrameworkLab.Model;
using EntityFrameworkLab.Requests;
using EntityFrameworkLab.View;
using EntityFrameworkLab.ViewModel;

namespace EntityFrameworkLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // модель представления данных
        private readonly MainWindowViewModel _model;
        private readonly ResDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new ResDbContext();
            // создали модель
            _model = new MainWindowViewModel
            {
                Researchers = new ObservableCollection<ResearcherViewModel>(
                    _context.Researchers.Select(
                        r => new ResearcherViewModel(r)
                        )
                    )
            };
            // связали с окном
            DataContext = _model;
            // 
            //AddResearcher();
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
            var resVm = _model.SelectedResearcher;
            var res = resVm.ToResearcher();
            _context.Researchers.Remove(res);
            _model.Researchers.Remove(resVm);
            _model.SelectedResearcher = null;
            _context.SaveChanges();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _model.SelectedResearcher = (ResearcherViewModel)e.AddedItems[0];
            }
        }

        #region Article managment
        //
        private void AddArticle()
        {
            var addWindow = new AddArticle(false, null);
            if (addWindow.ShowDialog() ?? false)
            {
                _model.SelectedResearcher.AddArticle(addWindow.Article);
            }
        }

        private void EditArticle()
        {
            var addWindow = new AddArticle(true, _model.SelectedArticle);
            addWindow.ShowDialog();
        }

        private void DeleteArticle()
        {
            if (_model.SelectedArticle == null) return;
            _model.SelectedResearcher.DeleteArticle(_model.SelectedArticle);
            _model.SelectedArticle = null;
        }
        #endregion

        #region Monograph managment
        //
        private void AddMonograph()
        {
            var addWindow = new AddMonograph(false, null);
            if (addWindow.ShowDialog() ?? false)
            {
                _model.SelectedResearcher.AddMonograph(addWindow.Monograph);
            }
        }

        private void EditMonograph()
        {
            var addWindow = new AddMonograph(true, _model.SelectedMonograph);
            addWindow.ShowDialog();
        }

        private void DeleteMonograph()
        {
            if (_model.SelectedMonograph == null) return;
            _model.SelectedResearcher.DeleteMonograph(_model.SelectedMonograph);
            _model.SelectedMonograph = null;
        }
        #endregion

        #region Presentation managment
        //
        private void AddPresentation()
        {
            var addWindow = new AddPresentation(false, null);
            if (addWindow.ShowDialog() ?? false)
            {
                _model.SelectedResearcher.AddPresentation(addWindow.Presentation);
            }
        }

        private void EditPresentation()
        {
            var addWindow = new AddPresentation(true, _model.SelectedPresentation);
            addWindow.ShowDialog();
        }

        private void DeletePresentation()
        {
            if (_model.SelectedPresentation == null) return;
            _model.SelectedResearcher.DeletePresentation(_model.SelectedPresentation);
            _model.SelectedPresentation = null;
        }
        #endregion

        #region Presentation managment
        //
        private void AddReport()
        {
            var addWindow = new AddReport(false, null);
            if (addWindow.ShowDialog() ?? false)
            {
                _model.SelectedResearcher.AddReport(addWindow.Report);
            }
        }

        private void EditReport()
        {
            var addWindow = new AddReport(true, _model.SelectedReport);
            addWindow.ShowDialog();
        }

        private void DeleteReport()
        {
            if (_model.SelectedReport == null) return;
            _model.SelectedResearcher.DeleteReport(_model.SelectedReport);
            _model.SelectedReport = null;
        }
        #endregion

        private void AddDataButton_Click(object sender, RoutedEventArgs e)
        {
            switch (ResearcherAchivementsTab.SelectedIndex)
            {
                case 0: AddReport(); break;
                case 1: AddArticle(); break;
                case 2: AddPresentation(); break;
                case 3: AddMonograph(); break;
            }
        }

        private void EditDataButton_Click(object sender, RoutedEventArgs e)
        {
            switch (ResearcherAchivementsTab.SelectedIndex)
            {
                case 0: EditReport(); break;
                case 1: EditArticle(); break;
                case 2: EditPresentation(); break;
                case 3: EditMonograph(); break;
            }
        }

        private void DeleteDataButton_Click(object sender, RoutedEventArgs e)
        {
            switch (ResearcherAchivementsTab.SelectedIndex)
            {
                case 0: DeleteReport(); break;
                case 1: DeleteArticle(); break;
                case 2: DeletePresentation(); break;
                case 3: DeleteMonograph(); break;
            }
        }

        private void ArticlesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _model.SelectedArticle = (ArticleViewModel)e.AddedItems[0];
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _model.SelectedReport = (ReportViewModel)e.AddedItems[0];
            }
        }

        private void DataGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _model.SelectedPresentation = (PresentationViewModel)e.AddedItems[0];
            }
        }

        private void DataGrid_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _model.SelectedMonograph = (MonographViewModel)e.AddedItems[0];
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _model.Researchers = string.IsNullOrWhiteSpace(SearchBox.Text) ? new ObservableCollection<ResearcherViewModel>(_context.Researchers.Select(r => new ResearcherViewModel(r))) : new ObservableCollection<ResearcherViewModel>(_context.Researchers.Where(r => r.LastName.StartsWith(SearchBox.Text) || r.FirstName.StartsWith(SearchBox.Text) || r.MiddleName.StartsWith(SearchBox.Text) || r.DepartmentNumber.Equals(SearchBox.Text) || r.Age.Equals(SearchBox.Text) || r.AcademicDegree.StartsWith(SearchBox.Text)).Select(r => new ResearcherViewModel(r)));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new Request();
            window.ShowDialog();
        }

        private void SearchBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (ResearcherAchivementsTab.SelectedIndex)
            {
                case 0: _model.Reports = string.IsNullOrWhiteSpace(SearchBox1.Text) ? new ObservableCollection<ReportViewModel>(_context.Reports.Select(r => new ReportViewModel(r))) : new ObservableCollection<ReportViewModel>(_context.Reports.Where(r => r.Name.StartsWith(SearchBox1.Text) || r.RegisterNumber == Convert.ToInt32(SearchBox1.Text) || r.ReleaseYear == Convert.ToInt32(SearchBox1.Text) || r.PageCount == Convert.ToInt32(SearchBox1.Text)).Select(r => new ReportViewModel(r))); break;
                case 1: _model.Articles = string.IsNullOrWhiteSpace(SearchBox1.Text) ? new ObservableCollection<ArticleViewModel>(_context.Articles.Select(r => new ArticleViewModel(r))) : new ObservableCollection<ArticleViewModel>(_context.Articles.Where(r => r.Name.StartsWith(SearchBox1.Text) || r.MagazineName.StartsWith(SearchBox1.Text)).Select(r => new ArticleViewModel(r))); break;
                    //case 2: DeletePresentation(); break;
                    //case 3: DeleteMonograph(); break;
            }
        }


        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void PART_MAXIMIZE_RESTORE_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == System.Windows.WindowState.Normal ? System.Windows.WindowState.Maximized : System.Windows.WindowState.Normal;
        }

        private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
