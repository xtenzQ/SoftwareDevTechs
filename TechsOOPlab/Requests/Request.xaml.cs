using System;
using System.Linq;
using System.Windows;
using TechsOOPlab.Model;

namespace TechsOOPlab.Requests
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        public Request()
        {
            InitializeComponent();
            Updown.ItemsSource = ModelContext.Researchers.GroupBy(x => x.DepartmentNumber).Select(y => y.First()).Select(r => r.DepartmentNumber);
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime1.Value == null) return;
            SearchResult1.Text = ModelContext.Presentations.Count(p => p.PresentationDate <= DateTime1.Value).ToString();
        }

        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Updown.Text)) return;
            SearchResult2.Text = ModelContext.Researchers.Where(x => x.DepartmentNumber == Convert.ToInt32(Updown.Text))
                .Sum(s => s.Reports.Sum(y => y.PageCount)).ToString();
        }
    }
}
