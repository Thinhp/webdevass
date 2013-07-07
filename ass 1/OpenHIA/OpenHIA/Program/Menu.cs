using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Program
{
    class Menu
    {
        public void displayMainMenu()
        {
            Console.WriteLine("1. Display doctors");
            Console.WriteLine("2. Display patients");
            Console.WriteLine("3. Display hospitals");
            Console.WriteLine("4. Display visit history");
            Console.WriteLine("5. Doctors CRUD");
            Console.WriteLine("6. Patients CRUD");
            Console.WriteLine("7. Hospital CRUD");
            Console.WriteLine("8. Visit CRUD");
            Console.Read();
        }
    }
}
