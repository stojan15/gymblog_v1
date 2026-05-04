using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymblog1.Models
{
    public class MacroTracker
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
    }
}