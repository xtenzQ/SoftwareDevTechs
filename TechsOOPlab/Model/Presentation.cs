using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsOOPlab.Model
{
    public class Presentation
    {
        public int Id;

        // Название доклада
        [DisplayName("Название доклада")]
        public string Name { get; set; }

        // Название конференции
        [DisplayName("Название конференции")]
        public string ConferenceName { get; set; }

        // Дата выступления
        [DisplayName("Дата выступления")]
        public DateTime PresentationDate { get; set; }
    }
}
