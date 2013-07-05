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
        public List<Doctors> doctors = new List<Doctors>();

        public DoctorList()
        {
            for (int i = 0; i < 5; i++)
            {
                doctors.Add(new Doctors("", "", "", ""));
            }
        }

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

        public Doctors this[int index]
        {
            get { return doctors[index]; }
            set { doctors[index] = value; }  
        }
    }
}
