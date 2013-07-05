using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Model;
using OpenHIA.Data;

namespace OpenHIA.Program
{
    class Program
    {
        public void start()
        {
            Console.WriteLine("========== Program starts ==========");

            var doctorList = new DoctorList();
            doctorList.[0] = new Doctors("Thinh", "28/2/1992","BBA102","102 3/2");

            Console.WriteLine(doctorList.doctors.Count());
            Console.Read();
        }
    }
}
