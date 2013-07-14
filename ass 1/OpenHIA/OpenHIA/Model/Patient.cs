using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Patient : Person
    {
        //Properties
        private static int currentId= 0;
        public string Gender { get; set; }

        /// <summary>
        /// Constructor to create patient instance
        /// </summary>
        /// <param name="name">Name of patient</param>
        /// <param name="gender">Gender of patient</param>
        /// <param name="dob">Patient date of birth</param>
        /// <param name="address">Address of patient</param>
        public Patient(string name, string gender, string dob, string address)
        {
            currentId++;
            this.Id = "P" + currentId;
            this.Name = name;
            this.Gender = gender;
            this.Dob = dob;
            this.Address = address;
        }

        public override string ToString()
        {
            string line = String.Format("{0,-5} {1,-15} {2,-15} {3,-10} {4,-15}", this.Id, this.Name, this.Dob, this.Gender, this.Address);
            return line; 
        }
    }
}
