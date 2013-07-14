using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Model;
using OpenHIA.Service;
using OpenHIA.Program;
using OpenHIA.Ultility;

namespace OpenHIA.Program
{
    class Program
    {
        private DataHandler datahandler = new DataHandler();

        /// <summary>
        /// Display the menu for user when starting the program
        /// prompt option: go directly to program, execute the test, or exit
        /// </summary>
        public void Start()
        {

            Console.WriteLine("========== OPENHIA ==========");
            Console.WriteLine("*****************************\n");

            //Populate sample data
            datahandler.PopulateSampleData();

            Menu.DisplayStartMenu();
            string option = Console.ReadLine();

            //A loop to display the start menu
            do
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("========== Program starts ==========");
                        Console.WriteLine("************************************");
                        RunMainMenu();
                        option = "3";
                        break;
                    case "2":
                        Console.WriteLine();
                        //TestProgramAction();
                        Menu.DisplayStartMenu();
                        option = Console.ReadLine();
                        break;
                    case "3":
                        return;
                    default:
                        Menu.DisplayErrorInput();
                        option = Console.ReadLine();
                        break;
                }

            } while(option != "3");

        }

        /// <summary>
        /// Main menu including 4 CRUD
        /// </summary>
        /// <param name="option">an option when user chooses</param>
        private void RunMainMenu()
        {
            string currentDisplay = "mainmenu";
            string option = "";            

            do
            {
                if(currentDisplay.Equals("mainmenu"))
                {
                    Console.WriteLine();
                    Menu.DisplayMainMenu();
                    option = Console.ReadLine();
                }

                switch (option)
                {
                    case "1":
                        currentDisplay = "mainmenu";
                        Console.WriteLine();
                        RunDoctorOption();
                        break;
                    case "2":
                        currentDisplay = "mainmenu";
                        Console.WriteLine();
                        RunPatientOption();
                        break;
                    case "3":
                        currentDisplay = "mainmenu";
                        Console.WriteLine();
                        RunHospitalOption();
                        break;
                    case "4":
                        currentDisplay = "mainmenu";
                        Console.WriteLine();
                        RunVisitOption();
                        break;
                    case "5":
                        currentDisplay = "mainmenu";
                        break;
                    default:
                        currentDisplay = "";
                        Menu.DisplayErrorInput();
                        option = Console.ReadLine();
                        break;

                }
            } while (option != "5");
        }

        private void RunDoctorOption()
        {
            string option = "";
            do{
                Menu.DisplayDoctorOption();
                option = Console.ReadLine();
                datahandler.DoctorHandler(ref option);

            } while (option != "5");

        }

        private void RunPatientOption()
        {
            string option = "";
            do
            {
                Menu.DisplayPatientOption();
                option = Console.ReadLine();
                datahandler.PatientHandler(ref option);

            } while (option != "5");
        }

        private void RunHospitalOption()
        {
            string option = "";
            do
            {
                Menu.DisplayHospitalOption();
                option = Console.ReadLine();
                datahandler.HospitalHandler(ref option);

            } while (option != "5");
        }

        private void RunVisitOption()
        {
            string option = "";
            do
            {
                Menu.DisplayVisitOption();
                option = Console.ReadLine();
                datahandler.VisitHandler(ref option);

            } while (option != "5");
        }
    }
}
