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
            Menu menu = new Menu();

            Console.WriteLine("========== Program starts ==========");
            Console.WriteLine("************************************");
            Console.WriteLine();
            menu.displayMainMenu();

            Console.Write("Hello " );
            Console.Read();
        }

        public void testData()
        {
            DoctorList docs = new DoctorList();
            Doctors adoc = new Doctors("Calencilla", "28/2/1992", "BB-23ab", "23A/15 Nguyen Thien Thuat");
            Doctors adoc2 = new Doctors("Alexander", "1/1/1993", "ab323CD", "123 3/2");
            Doctors adoc3 = new Doctors("Bolland", "8/3/1995", "ABCD", "123 3/2");
            docs.Create(adoc);
            docs.Create(adoc2);
            docs.Create(adoc3);
            docs.GetAllRecords();
            string updateString = "Dillan";
            string updateId = "D3";
            Doctors temp = docs.Read(updateId);
            temp.Name = updateString;
            docs.Update(temp);

            Console.ReadLine();
            docs.GetAllRecords();
            Console.Read();
        }
    }
}
