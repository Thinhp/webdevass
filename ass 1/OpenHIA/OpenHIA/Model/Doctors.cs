using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Doctors : Person
    {

        //Properties
        private static int currentID = 0;
        public string LicenseNumber { get; set; }

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
            this.Id = currentID;
            this.Name = doctorName;
            this.Dob = doctorDOB;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }

    }
}
