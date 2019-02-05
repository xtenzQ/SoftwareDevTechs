using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace TechsOOPlab.Model
{
    // Researcher class
    public class Researcher
    {
        public int Id { get; set; }

        // ФИО
        public string LastName { get; set; }  
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        // Номер отдела
        public int DepartmentNumber { get; set; }

        // Возраст
        public int Age { get; set; }

        // Ученая степень
        public string AcademicDegree { get; set; }

        // Должность
        public string Position { get; set; }

        // Список статей
        public List<Article> Articles { get; set; }
        // Список монографий
        public List<Monograph> Monographs { get; set; }
        // Список докладов
        public List<Presentation> Presentations { get; set; }
        // Список научных отчётов
        public List<Report> Reports { get; set; }

        public Researcher()
        {

            Articles = new List<Article>();
            Monographs = new List<Monograph>();
            Presentations = new List<Presentation>();
            Reports = new List<Report>();
        }
    }
}