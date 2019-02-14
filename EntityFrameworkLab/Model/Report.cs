﻿namespace EntityFrameworkLab.Model
{
    // Научный отчёт
    public class Report
    {
        public int Id { get; set; }

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
