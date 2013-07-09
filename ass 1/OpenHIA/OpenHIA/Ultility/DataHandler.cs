using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Service;
using OpenHIA.Program;

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
                        Console.WriteLine("Inside Doctor handler");
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
