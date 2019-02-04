using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsOOPlab.Model
{
    public class Article
    {
        public int Id { get; set; }

        // Название статьи
        public string Name { get; set; }

        // Название журнала
        public string MagazineName { get; set; }

        // Год и месяц издания
        public DateTime ReleaseDate { get; set; }
    }
}
