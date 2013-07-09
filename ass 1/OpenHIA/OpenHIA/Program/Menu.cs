using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Program
{
    class Menu
    {

        /// <summary>
        /// Display the first menu when user starts the program
        /// including either testin the program or go directly to it
        /// </summary>
        public void DisplayStartMenu()
        {
            Console.WriteLine("1. Start the program");
            Console.WriteLine("2. Test the program");
            Console.WriteLine("3. Exit");
            Console.Write("Please choose an option: ");
        }

        /// <summary>
        /// Display the main menu of the system
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("1. Doctors CRUD");
            Console.WriteLine("2. Patients CRUD");
            Console.WriteLine("3. Hospital CRUD");
            Console.WriteLine("4. Visit CRUD");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose an option: ");
        }

        public void DisplayDoctorOption()
        {

        }

        public void DisplayPatientOption()
        {

        }

        public void DisplayHospitalOption()
        {

        }

        /// <summary>
        public void DisplayVisitOption()
        {

        }

        /// Display invalid input error message of the system
        /// </summary>
        public void DisplayErrorInput()
        {
            Console.Write("Invalid input. Please enter again: ");
        }
    }
}
