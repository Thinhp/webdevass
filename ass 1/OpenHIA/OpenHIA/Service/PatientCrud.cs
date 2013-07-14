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
    public class PatientCrud : IMaintanble<Patient>
    {

        public void GetAllRecords()
        {
            Console.WriteLine("Id" + "    " + "Name" + "               " + "Date of birth" + "      " +
                "Gender" + "  " + "Address");
            foreach (Patient pa in Database.PatientList)
            {
                Console.WriteLine(pa.ToString());
            }
        }

        public void Create(Patient obj)
        {
            Database.PatientList.Add(obj);
            Database.PatientList.Sort();

        }

        public Patient Read(string key)
        {
            // Loop through doctor list and get doctor object based on 'key'
            foreach (Patient pa in Database.PatientList)
            {
                if (pa.Id.Equals(key))
                {
                    return pa;
                }
            }

            throw new InvalidPatientsInformationException("No patient found");
        }

        public void Update(Patient obj)
        {
            foreach (Patient pa in Database.PatientList)
            {
                if (pa.Id.Equals(obj.Id))
                {
                    pa.Name = obj.Name;
                    pa.Dob = obj.Dob;
                    pa.Gender = obj.Gender;
                    pa.Address = obj.Address;
                    Database.PatientList.Sort();
                    break;
                }
            }
        }

        public void Delete(string key)
        {
            foreach (Patient pa in Database.PatientList)
            {
                if (pa.Id.Equals(key))
                {
                    Database.PatientList.Remove(pa);
                    break;
                }
            }
        }
    }
}
