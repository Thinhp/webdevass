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
    public class HospitalCrud : IMaintanble<Hospital>
    {
        public void GetAllRecords()
        {
            string line = String.Format("{0,-5} {1,-15} {2,-15} {3,-15}", "Id", "Name", "License number", "Address");
            Console.WriteLine(line);
            foreach (Hospital hos in Database.HospitalList)
            {
                Console.WriteLine(hos.ToString());
            }
        }

        public void Create(Hospital obj)
        {
            Database.HospitalList.Add(obj);
        }

        public Hospital Read(string key)
        {
            // Loop through doctor list and get doctor object based on 'key'
            foreach (Hospital hos in Database.HospitalList)
            {
                if (hos.Id.Equals(key) || hos.Name.Equals(key))
                {
                    return hos;
                }
            }

            throw new InvalidHospitalInformationException("******* No hospital found *******\n");
        }

        public void Update(Hospital obj)
        {
            foreach (Hospital hos in Database.HospitalList)
            {
                if (hos.Id.Equals(obj.Id))
                {
                    hos.Name = obj.Name;
                    hos.LicenseNumber = obj.LicenseNumber;
                    hos.Address = obj.Address;
                    Database.HospitalList.Sort();
                    break;
                }
            }
        }

        public void Delete(string key)
        {
            foreach (Hospital hos in Database.HospitalList)
            {
                if (hos.Id.Equals(key))
                {
                    Database.HospitalList.Remove(hos);
                    break;
                }
            }
        }
    }
}
