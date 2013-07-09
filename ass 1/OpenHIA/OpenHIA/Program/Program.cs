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
                        Console.WriteLine("************************************\n");
                        RunMainMenu();
                        option = "3";
                        break;
                    case "2":
                        Console.WriteLine();
                        TestProgramAction();
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
                    Menu.DisplayMainMenu();
                    option = Console.ReadLine();
                }

                switch (option)
                {
                    case "1":
                        currentDisplay = "mainmenu";
                        Console.WriteLine();
                        Menu.DisplayDoctorOption();
                        option = Console.ReadLine();
                        datahandler.DoctorHandler(option);
                        break;
                    case "2":
                        currentDisplay = "mainmenu";
                        break;
                    case "3":
                        currentDisplay = "mainmenu";
                        break;
                    case "4":
                        currentDisplay = "mainmenu";
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

        private void TestProgramAction()
        {

        }

        //public void testData()
        //{
        //    DoctorCrud docs = new DoctorCrud();
        //    Doctors adoc = new Doctors("Calencilla", "28/2/1992", "BB-23ab", "23A/15 Nguyen Thien Thuat");
        //    Doctors adoc2 = new Doctors("Alexander", "1/1/1993", "ab323CD", "123 3/2");
        //    Doctors adoc3 = new Doctors("Bolland", "8/3/1995", "ABCD", "123 3/2");
        //    docs.Create(adoc);
        //    docs.Create(adoc2);
        //    docs.Create(adoc3);
        //    docs.GetAllRecords();
        //    string updateString = "Dillan";
        //    string updateId = "D3";
        //    Doctors temp = docs.Read(updateId);
        //    temp.Name = updateString;
        //    docs.Update(temp);

        //    Console.ReadLine();
        //    docs.GetAllRecords();
        //    Console.Read();
        //}
    }
}
