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
        public Hospital Place { get; set; }
        public Patient TreatedPatient { get; set; }
        public Doctor TreatingDoctor { get; set; }
        public string Diagnosis { get; set; }
        public string Outcome { get; set; }

        public Visit(string treatedDate, Hospital place, Patient patient, Doctor doctor,
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

        public override string ToString()
        {
            string line = String.Format("{0,-5} {1,-10} {2,-10} {3,-15} {4, -15} {5,-15} {6,-15}", this.Id, this.TreatedPatient.Id, 
                this.TreatingDoctor.Id, this.TreatedDate, this.Place.Name, this.Diagnosis, this.Outcome);
            return line; 
        }
    }
}
