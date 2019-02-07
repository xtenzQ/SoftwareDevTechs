using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsOOPlab.Model
{
    public class Article : IDataErrorInfo
    {
        public int Id { get; set; }

        // Название статьи
        public string Name { get; set; }

        // Название журнала
        public string MagazineName { get; set; }

        // Год и месяц издания
        public DateTime ReleaseDate { get; set; }


        public string this[string columnName] => throw new NotImplementedException();

        public string Error { get; }
    }
}
