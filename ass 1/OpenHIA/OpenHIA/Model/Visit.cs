using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Model
{
    public class Visit
    {

        // Properties
        private static int currentId = 0;
        public int Id { get; set; }
        public DateTime TreatedDate { get; set; }
        public string Place { get; set; }
        public Patients TreatedPatient { get; set; }
        public Doctors TreatingDoctor { get; set; }
        public string Diagnosis { get; set; }
        public string Outcome { get; set; }

        public Visit(DateTime treatedDate, string place, Patients patient, Doctors doctor,
            string diagnosis, string outcome)
        {
            currentId++;
            this.Id = currentId;
            this.TreatedDate = treatedDate;
            this.Place = place;
            this.TreatedPatient = patient;
            this.TreatingDoctor = doctor;
            this.Outcome = outcome;
            this.Diagnosis = diagnosis;

        }
    }
}
