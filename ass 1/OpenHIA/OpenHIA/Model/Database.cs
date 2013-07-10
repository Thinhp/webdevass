using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Database
    {
        public static List<Doctors> DoctorList = new List<Doctors>();
        public static List<Patients> PatientList = new List<Patients>();
        public static List<Hospitals> HospitalList = new List<Hospitals>();
        public static List<Visit> VisitList = new List<Visit>();
    }
}
