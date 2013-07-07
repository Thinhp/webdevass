using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Interface;

namespace OpenHIA.Model
{
    public class Doctors : Person, IControllable
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
        public Doctors(string doctorName, string doctorDOB, string licenseNumber, string address)
        {
            currentId++;
            this.Id = "D" + currentId;
            this.Name = doctorName;
            this.Dob = doctorDOB;
            this.LicenseNumber = licenseNumber;
            this.Address = address;
        }


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Doctors otherDoctor = obj as Doctors;
            if (otherDoctor != null)
            {
                return this.Id.CompareTo(otherDoctor.Id);
            }
            else
            {
                throw new ArgumentException("Object is not a Doctor");
            }
            
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Id + "    " + this.Name;
        }

        
    }
}
