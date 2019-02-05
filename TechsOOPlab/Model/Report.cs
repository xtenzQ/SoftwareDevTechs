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
        public string Name { get; set; }

        // Регистрационный номер
        public int RegisterNumber { get; set; }

        // Год выпуска
        public int ReleaseYear { get; set; }
        
        // Число страниц
        public int PageCount { get; set; }
    }
}
