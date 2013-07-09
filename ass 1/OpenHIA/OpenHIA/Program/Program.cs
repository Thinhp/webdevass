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
        private Menu menu = new Menu();

        /// <summary>
        /// Display the menu for user when starting the program
        /// prompt option: go directly to program, execute the test, or exit
        /// </summary>
        public void Start()
        {

            Console.WriteLine("========== OPENHIA ==========");
            Console.WriteLine("*****************************\n");

            menu.DisplayStartMenu();
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
                        option = "start";
                        RunMainMenu(ref option);
                        option = "3";
                        break;
                    case "2":
                        Console.WriteLine();
                        TestProgramAction();
                        menu.DisplayStartMenu();
                        option = Console.ReadLine();
                        break;
                    case "3":
                        return;
                    default:
                        menu.DisplayErrorInput();
                        option = Console.ReadLine();
                        break;
                }

            } while(option != "3");

        }

        private void RunMainMenu(ref string option)
        {
            do
            {
                switch (option)
                {
                    case "start":
                        menu.DisplayMainMenu();
                        option = Console.ReadLine();
                        break;
                    case "1":
                        menu.DisplayDoctorOption();
                        option = Console.ReadLine();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        menu.DisplayErrorInput();
                        menu.DisplayMainMenu();
                        option = Console.ReadLine();
                        break;

                }
            } while (option != "5");
        }

        private void TestProgramAction()
        {

        }

        public void testData()
        {
            DoctorCrud docs = new DoctorCrud();
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
