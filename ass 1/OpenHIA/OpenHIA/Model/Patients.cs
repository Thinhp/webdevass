using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Patients : Person
    {
        private static int currentID= 0;

        /// <summary>
        /// Constructor to create patient instance
        /// </summary>
        /// <param name="name">Name of patient</param>
        /// <param name="gender">Gender of patient</param>
        /// <param name="dob">Patient date of birth</param>
        /// <param name="address">Address of patient</param>
        public Patients(string name, string gender, string dob, string address)
        {
            currentID++;
            this.Id = "P" + currentID;
            this.Name = name;
            this.Gender = gender;
            this.Dob = dob;
            this.Address = address;
        }

        /// <summary>
        /// Getters and setters for properties
        /// </summary>
        public string Gender { get; set; }
    }
}
