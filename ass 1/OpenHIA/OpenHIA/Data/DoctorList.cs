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
        // Doctor list to hold doctor database
        private List<Doctors> doctorsList = new List<Doctors>();

        public void Create(Doctors obj)
        {
            doctorsList.Add(obj);
        }

        public Doctors Read(string key)
        {
            foreach (Doctors doc in doctorsList)
            {
                if (doc.Id.Equals(key))
                {
                    return doc;
                }
            }

            throw new InvalidDoctorsInformationException("No doctor found");  
        }

        public void Update(Doctors obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }


        public void GetAllRecords()
        {
            Console.WriteLine("Id" + "    " + "Name");
            foreach (Doctors doc in doctorsList)
            {
                Console.WriteLine(doc.ToString());
            }
        }
    }
}
