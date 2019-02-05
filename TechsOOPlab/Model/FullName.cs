using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsOOPlab.Model
{
    // Структура ФИО
    public struct FullName
    {
        private string _surname;
        private string _givenName;
        private string _middleName;


        public FullName(string surname, string givenName, string middleName)
        {
            _surname = surname;
            _givenName = givenName;
            _middleName = middleName;
        }
    }
}
