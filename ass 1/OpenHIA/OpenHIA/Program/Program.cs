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

        public void Start()
        {

            Console.WriteLine("========== Program starts ==========");
            Console.WriteLine("************************************\n");

            string option = "start";
            string currentMenu = "mainmenu";
            do
            {
                switch (currentMenu)
                {
                    case "mainmenu": 
                        MainMenuAction(ref option);
                        break;
                    default:
                        break;
                }
            } while (option != "5" && currentMenu == "mainmenu");

        }

        private void MainMenuAction(ref string option)
        {
            switch (option)
            {
                case "start":
                    menu.DisplayMainMenu();
                    option = Console.ReadLine();
                    break;
                case "5":
                    break;
                default:
                    menu.DisplayErrorInput();
                    menu.DisplayMainMenu();
                    option = Console.ReadLine();
                    break;
            }
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
