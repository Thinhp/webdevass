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
            Console.WriteLine("1. Doctors CRUD");
            Console.WriteLine("2. Patients CRUD");
            Console.WriteLine("3. Hospital CRUD");
            Console.WriteLine("4. Visit CRUD");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Please choose an option: ");
        }

        public void displayErrorInput()
        {
            Console.WriteLine("Invalid input. Please enter again\n");
        }
    }
}
