using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Visit
    {

        /// <summary>
        /// Getters and Setters for properties
        /// </summary>
        public DateTime MyProperty { get; set; }
        public string Place { get; set; }
        public Doctors TreatingDoctor { get; set; }
        public string Diagnosis { get; set; }
        public string Outcome { get; set; }
    }
}
