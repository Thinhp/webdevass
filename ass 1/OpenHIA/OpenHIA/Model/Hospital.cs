using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Hospital
    {
        //Properties
        private static int currentId = 0;
        public string Name { get; set; }
        public string Id { get; set; }
        public string LicenseNumber { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Constructor to create hosptial instance with hospital name, license number,
        /// address and auto-increment id
        /// </summary>
        /// <param name="hospitalName">Hospita's name</param>
        /// <param name="licenseNumber">Hospital's license number</param>
        /// <param name="address"> Hospital's address</param>
        public Hospital(string hospitalName, string licenseNumber, string address)
        {
            currentId++;
            this.Id = "H" + currentId;
            this.Name = hospitalName;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }

        public override string ToString()
        {
            string line = String.Format("{0,-5} {1,-15} {2,-15} {3,-15}", this.Id, this.Name, this.LicenseNumber, this.Address);
            return line; 
        }

    }
}
