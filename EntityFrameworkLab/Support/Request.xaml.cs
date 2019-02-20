using System;
using System.Linq;
using System.Windows;
using EntityFrameworkLab.Model;

namespace EntityFrameworkLab.Requests
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        private readonly ResDbContext _resDbContext;

        public Request()
        {
            InitializeComponent();
            Updown.ItemsSource = _resDbContext.Researchers.GroupBy(x => x.DepartmentNumber).Select(y => y.First()).Select(r => r.DepartmentNumber);
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime1.Value == null) return;
            SearchResult1.Text = _resDbContext.Presentations.Count(p => p.PresentationDate <= DateTime1.Value).ToString();
        }

        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Updown.Text)) return;
            SearchResult2.Text = _resDbContext.Researchers.Where(x => x.DepartmentNumber == Convert.ToInt32(Updown.Text))
                .Sum(s => _resDbContext.Reports.Sum(y => y.PageCount)).ToString();
        }
    }
}
