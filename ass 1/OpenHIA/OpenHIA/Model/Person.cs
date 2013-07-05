using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public abstract class Person
    {
        //Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
    }
}
