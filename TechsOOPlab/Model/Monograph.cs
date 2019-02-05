using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsOOPlab.Model
{
    public class Monograph
    {
        public int Id { get; set; }

        // Название монографии
        public string Name { get; set; }

        // ФИО соавтора
        public FullName CoauthorName { get; set; }

        // Год издания
        public DateTime ReleaseDate { get; set; }

        // Число страниц
        public int PageCount { get; set; }
    }
}
