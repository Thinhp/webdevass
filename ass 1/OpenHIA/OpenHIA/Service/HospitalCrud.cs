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
            Console.WriteLine("Id" + "    " + "Name" + "               " + 
                "License Number" + "  " + "Address");
            foreach (Hospital hos in Database.HospitalList)
            {
                Console.WriteLine(hos.ToString());
            }
        }

        public void Create(Hospital obj)
        {
            Database.HospitalList.Add(obj);
            Database.HospitalList.Sort();
        }

        public Hospital Read(string key)
        {
            // Loop through doctor list and get doctor object based on 'key'
            foreach (Hospital hos in Database.HospitalList)
            {
                if (hos.Id.Equals(key))
                {
                    return hos;
                }
            }

            throw new InvalidHospitalInformationException("No hospital found");
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
