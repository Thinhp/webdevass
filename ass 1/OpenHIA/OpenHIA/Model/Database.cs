using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Model;

namespace OpenHIA.Data
{
    public class Database
    {
        public static List<Doctors> DoctorList { get; set; }
        public static List<Patients> PatientList { get; set; }
        public static List<Hospitals> HospitalList { get; set; }
        public static List<Visit> VisitList { get; set; }
    }
}
