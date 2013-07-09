using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Service;

namespace OpenHIA.Ultility
{
    class DataHandler
    {
        private DoctorCrud doctormanager = new DoctorCrud();
        private PatientCrud patientmanager = new PatientCrud();
        private HospitalCrud hospitalmanager = new HospitalCrud();

        public void DoctorHandler(string option)
        {
            switch (option)
            {
                case "1":
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
