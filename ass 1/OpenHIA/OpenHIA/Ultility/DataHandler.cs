using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Service;
using OpenHIA.Program;
using OpenHIA.Model;

namespace OpenHIA.Ultility
{
    public class DataHandler
    {
        private DoctorCrud doctormanager = new DoctorCrud();
        private PatientCrud patientmanager = new PatientCrud();
        private HospitalCrud hospitalmanager = new HospitalCrud();

        public void DoctorHandler(string option)
        {
                switch (option)
                {
                    case "1":
                        Console.Write("Enter doctor's name: ");
                        string doctorname = Console.ReadLine();
                        Console.Write("Enter doctor's Date of birth(dd/mm/yyyy): ");
                        string doctordob = Console.ReadLine();
                        Console.Write("Enter doctor's license number: ");
                        string license = Console.ReadLine();
                        Console.Write("Enter doctor's address: ");
                        string address = Console.ReadLine();
                        Doctors newdoc = new Doctors(doctorname, doctordob, license, address);
                        doctormanager.Create(newdoc);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        doctormanager.GetAllRecords();
                        break;
                    case "5":
                        break;
                    default:
                        Menu.DisplayErrorInput();
                        option = Console.ReadLine();
                        break;
                }
        }

        public void PatientHandler(string option)
        {

        }

        public void HospitalHandler(string option)
        {

        }

        public void VisitHandler(string option)
        {

        }
    }
}
