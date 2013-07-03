using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    class Patients
    {
        private static int currentID= 0;

        public Patients(string name, string gender, string dob, string address)
        {
            currentID++;
            this.PatientID = "P" + currentID;
            this.Name = name;
            this.Gender = gender;
            this.Dob = dob;
            this.Address = address;
        }

        public string PatientID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
    }
}
