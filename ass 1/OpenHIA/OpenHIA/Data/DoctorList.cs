using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Interface;
using OpenHIA.Model;

namespace OpenHIA.Data
{
    public class DoctorList : IMaintanble<Doctors>
    {
        public List<Doctors> Doctors { get; set; }

        public void Create(Doctors obj)
        {
            throw new NotImplementedException();
        }

        public Doctors Read(string key)
        {
            throw new NotImplementedException();
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
            foreach (var doc in Doctors)
            {
                Console.WriteLine("
            }
        }
    }
}
