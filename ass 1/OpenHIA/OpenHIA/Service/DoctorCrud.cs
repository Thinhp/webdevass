using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Interface;
using OpenHIA.Model;
using OpenHIA.Exceptions;

namespace OpenHIA.Service
{
    public class DoctorCrud : IMaintanble<Doctor>
    {
        // Properties: doctor list to hold doctor database

        /// <summary>
        /// Crud operation: Create a new doctor object
        /// </summary>
        /// <param name="obj">a doctor object to add to list</param>
        public void Create(Doctor obj)
        {
            Database.DoctorList.Add(obj);
            Database.DoctorList.Sort();
        }

        /// <summary>
        /// Crud operation: Read id from doctor and return a doctor object
        /// </summary>
        /// <param name="key">doctor's id or name</param>
        /// <returns></returns>
        public Doctor Read(string key)
        {
            // Loop through doctor list and get doctor object based on 'key'
            foreach (Doctor doc in Database.DoctorList)
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
        public void Update(Doctor obj)
        {
            foreach (Doctor doc in Database.DoctorList)
            {
                if (doc.Id.Equals(obj.Id))
                {
                    doc.Name = obj.Name;
                    doc.Dob = obj.Dob;
                    doc.LicenseNumber = obj.LicenseNumber;
                    doc.Address = obj.Address;
                    Database.DoctorList.Sort();
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
            foreach (Doctor doc in Database.DoctorList)
            {
                if (doc.Id.Equals(key))
                {
                    Database.DoctorList.Remove(doc);
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
            foreach (Doctor doc in Database.DoctorList)
            {
                Console.WriteLine(doc.ToString());
            }
        }
    }
}
