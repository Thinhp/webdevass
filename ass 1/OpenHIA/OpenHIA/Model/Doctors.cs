using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Doctors : Person
    {

        private static int currentID = 0;

        /// <summary>
        /// Constructor to create doctor instance
        /// </summary>
        /// <param name="doctorName">Doctor's name</param>
        /// <param name="doctorDOB">Doctor's date of birth</param>
        /// <param name="licenseNumber">Doctor's licenseNumber</param>
        /// <param name="address">Doctor's address</param>
        public Doctors(string doctorName, string doctorDOB, string licenseNumber, string address)
        {
            currentID++;
            this.Id = "D" + currentID;
            this.Name = doctorName;
            this.Dob = doctorDOB;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }

        /// <summary>
        /// Getters and Setters
        /// </summary>

        public string LicenseNumber { get; set; }
    }
}
