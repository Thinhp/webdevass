using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Interface;

namespace OpenHIA.Model
{
    public class Doctor : Person
    {

        //Properties
        private static int currentId = 0;
        public string LicenseNumber { get; set; }

        /// <summary>
        /// Constructor to create doctor instance
        /// </summary>
        /// <param name="doctorName">Doctor's name</param>
        /// <param name="doctorDOB">Doctor's date of birth</param>
        /// <param name="licenseNumber">Doctor's licenseNumber</param>
        /// <param name="address">Doctor's address</param>
        public Doctor(string doctorName, string doctorDOB, string licenseNumber, string address)
        {
            currentId++;
            this.Id = "D" + currentId;
            this.Name = doctorName;
            this.Dob = doctorDOB;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }
        
        /// <summary>
        /// Override ToString() method to display to console
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Id + "    " + this.Name + "              " + this.Dob + "          " + this.LicenseNumber +
                "            " + this.Address;
        }

        
    }
}
