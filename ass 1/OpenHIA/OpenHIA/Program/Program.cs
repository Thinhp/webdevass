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
            Console.WriteLine("************************************");

            DoctorList docs = new DoctorList();
            Doctors adoc = new Doctors("Thinh", "28/2/1992", "ABCD", "123 3/2");
            Doctors adoc2 = new Doctors("Thinh", "28/2/1992", "ABCD", "123 3/2");
            Doctors adoc3 = new Doctors("Thinh", "28/2/1992", "ABCD", "123 3/2");
            docs.Create(adoc);
            docs.Create(adoc2);
            docs.Create(adoc3);
            docs.GetAllRecords();
            Console.Read();
        }
    }
}
