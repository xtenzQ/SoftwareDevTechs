using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsOOPlab.Model
{
    // Научный отчёт
    public class Report
    {
        public int Id;

        // Название научного отчёта
        [DisplayName("Название доклада")]
        public string Name { get; set; }

        // Регистрационный номер
        [DisplayName("Регистрационный номер")]
        public int RegisterNumber { get; set; }

        // Год выпуска
        [DisplayName("Год выпуска")]
        public int ReleaseYear { get; set; }
        
        // Число страниц
        [DisplayName("Число страниц")]
        public int PageCount { get; set; }
    }
}
