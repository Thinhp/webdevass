using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    class Hospitals
    {
        private static int currentID = 0;

        /// <summary>
        /// Constructor to create hosptial instance with hospital name, license number,
        /// address and auto-increment id
        /// </summary>
        /// <param name="hospitalName">Hospita's name</param>
        /// <param name="licenseNumber">Hospital's license number</param>
        /// <param name="address"> Hospital's address</param>
        public Hospitals(string hospitalName, string licenseNumber, string address)
        {
            currentID++;
            this.HosptialID = "H" + currentID;
            this.HospitalName = hospitalName;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }

        /// <summary>
        /// Getters and Setters
        /// </summary>
        public string HospitalName { get; set; }

        public string HosptialID { get; set; }

        public string LicenseNumber { get; set; }

        public string Address { get; set; }
    }
}
