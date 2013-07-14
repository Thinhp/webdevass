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
        public string Id { get; set; }
        public string TreatedDate { get; set; }
        public string Place { get; set; }
        public Patient TreatedPatient { get; set; }
        public Doctor TreatingDoctor { get; set; }
        public string Diagnosis { get; set; }
        public string Outcome { get; set; }

        public Visit(string treatedDate, string place, Patient patient, Doctor doctor,
            string diagnosis, string outcome)
        {
            currentId++;
            this.Id = "V" + currentId;
            this.TreatedDate = treatedDate;
            this.Place = place;
            this.TreatedPatient = patient;
            this.TreatingDoctor = doctor;
            this.Outcome = outcome;
            this.Diagnosis = diagnosis;

        }
    }
}
