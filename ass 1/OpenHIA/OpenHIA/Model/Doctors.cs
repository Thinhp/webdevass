using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Doctors
    {

        /// <summary>
        /// Properties to store Doctor data
        /// </summary>
        private static int currentID = 0;

        /// <summary>
        /// Constructor to create doctors
        /// </summary>
        /// <param name="doctorName">Doctor's name</param>
        /// <param name="doctorDOB">Doctor's date of birth</param>
        /// <param name="licenseNumber">Doctor's licenseNumber</param>
        /// <param name="address">Doctor's address</param>
        public Doctors(string doctorName, string doctorDOB, string licenseNumber, string address)
        {
            currentID++;
            this.DoctorID = "D" + currentID;
            this.DoctorName = doctorName;
            this.DoctorDOB = doctorDOB;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }

        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDOB { get; set; }
        public string LicenseNumber { get; set; }
        public string Address { get; set; }
    }
}
