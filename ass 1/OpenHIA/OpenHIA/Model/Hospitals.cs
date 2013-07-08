using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Hospitals
    {
        //Properties
        private static int currentId = 0;
        public string HospitalName { get; set; }
        public string HosptialId { get; set; }
        public string LicenseNumber { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Constructor to create hosptial instance with hospital name, license number,
        /// address and auto-increment id
        /// </summary>
        /// <param name="hospitalName">Hospita's name</param>
        /// <param name="licenseNumber">Hospital's license number</param>
        /// <param name="address"> Hospital's address</param>
        public Hospitals(string hospitalName, string licenseNumber, string address)
        {
            currentId++;
            this.HosptialId = "H" + currentId;
            this.HospitalName = hospitalName;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }

    }
}
