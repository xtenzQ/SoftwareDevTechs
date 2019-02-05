using System.Collections.Generic;

namespace TechsOOPlab.Model
{
    public static class ModelContext
    {
        public static List<Researcher> Researchers { get; set; }
        public static List<Article> Articles { get; set; }
        public static List<Report> Reports { get; set; }
        public static List<Presentation> Presentations { get; set; }
        public static List<Monograph> Monographs { get; set; }

        static ModelContext()
        {
            Researchers = new List<Researcher>();
            Articles = new List<Article>();
            Reports = new List<Report>();
            Presentations = new List<Presentation>();
            Monographs = new List<Monograph>();
        }
    }
}