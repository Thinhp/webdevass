using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Interface;
using OpenHIA.Model;
using OpenHIA.Exceptions;

namespace OpenHIA.Data
{
    public class DoctorList : IMaintanble<Doctors>
    {
        // Properties: doctor list to hold doctor database
        private List<Doctors> doctorsList = new List<Doctors>();

        /// <summary>
        /// Crud operation: Create a new doctor object
        /// </summary>
        /// <param name="obj">a doctor object to add to list</param>
        public void Create(Doctors obj)
        {
            doctorsList.Add(obj);
            doctorsList.Sort();
        }

        /// <summary>
        /// Crud operation: Read id from doctor and return a doctor object
        /// </summary>
        /// <param name="key">doctor's id</param>
        /// <returns></returns>
        public Doctors Read(string key)
        {
            // Loop through doctor list and get doctor object based on 'key'
            foreach (Doctors doc in doctorsList)
            {
                if (doc.Id.Equals(key))
                {
                    return doc;
                }
            }

            throw new InvalidDoctorsInformationException("No doctor found");  
        }

        /// <summary>
        /// Crud operation: Update the doctor list 
        /// </summary>
        /// <param name="obj">doctor object to update</param>
        public void Update(Doctors obj)
        {
            foreach (Doctors doc in doctorsList)
            {
                if (doc.Id.Equals(obj.Id))
                {
                    doc.Name = obj.Name;
                    doc.Dob = obj.Dob;
                    doc.LicenseNumber = obj.LicenseNumber;
                    doc.Address = obj.Address;
                    doctorsList.Sort();
                    break;
                }
            }
        }

        /// <summary>
        /// Crud operaition: Delete doctor based on key id
        /// </summary>
        /// <param name="key">doctor's id</param>
        public void Delete(string key)
        {
            foreach (Doctors doc in doctorsList)
            {
                if (doc.Id.Equals(key))
                {
                    doctorsList.Remove(doc);
                    break;
                }
            }
        }

        /// <summary>
        /// Get all records on the list
        /// </summary>
        public void GetAllRecords()
        {
            Console.WriteLine("Id" + "    " + "Name" + "               " + "Date of birth" + "      " + 
                "License Number" + "  " + "Address");
            foreach (Doctors doc in doctorsList)
            {
                Console.WriteLine(doc.ToString());
            }
        }
    }
}
