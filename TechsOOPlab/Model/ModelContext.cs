using System.Collections.Generic;

namespace TechsOOPlab.Model
{
    public static class ModelContext
    {
        public static List<Researcher> Researchers { get; set; }

        static ModelContext()
        {
            Researchers = new List<Researcher>();
        }
    }
}