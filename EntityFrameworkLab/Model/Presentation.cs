using System;

namespace EntityFrameworkLab.Model
{
    public class Presentation
    {
        public int Id { get; set; }

        // Название доклада
        public string Name { get; set; }

        // Название конференции
        public string ConferenceName { get; set; }

        // Дата выступления
        public DateTime PresentationDate { get; set; }
    }
}
