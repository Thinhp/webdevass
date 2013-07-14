using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Service;
using OpenHIA.Program;
using OpenHIA.Model;
using OpenHIA.Exceptions;

namespace OpenHIA.Ultility
{
    public class DataHandler
    {
        private DoctorCrud doctormanager = new DoctorCrud();
        private PatientCrud patientmanager = new PatientCrud();
        private HospitalCrud hospitalmanager = new HospitalCrud();
        private VisitCrud visitmanager = new VisitCrud();

        DataValidation datavalidation = new DataValidation();

        public bool compareListOption(string original, string[] listOfOption)
        {
            foreach (string row in listOfOption)
            {
                if (row.Equals(original))
                {
                    return true;
                }
            }
            return false;
        }

        public void DoctorHandler(ref string option)
        {
            do
            {

                switch (option)
                {
                    case "1":
                        DoctorOption1();
                        return;
                    case "2":
                        DoctorOption2();
                        return;
                    case "3":
                        DoctorOption3();
                        return;
                    case "4":
                        DoctorOption4();
                        return;
                    case "5":
                        break;
                    default:
                        Menu.DisplayErrorInput("Invalid input. Please enter from 1 - 5: ");
                        option = Console.ReadLine();
                        break;
                }
            } while (option != "5");
        }

        public void PatientHandler(ref string option)
        {
            do
            {

                switch (option)
                {
                    case "1":
                        PatientOption1();
                        return;
                    case "2":
                        PatientOption2();
                        return;
                    case "3":
                        PatientOption3();
                        return;
                    case "4":
                        PatientOption4();
                        return;
                    case "5":
                        break;
                    default:
                        Menu.DisplayErrorInput("Invalid input. Please enter from 1 - 5: ");
                        option = Console.ReadLine();
                        break;
                }
            } while (option != "5");

        }

        public void HospitalHandler(ref string option)
        {
            do
            {
                switch (option)
                {
                    case "1":
                        HospitalOption1();
                        return;
                    case "2":
                        HospitalOption2();
                        return;
                    case "3":
                        HospitalOption3();
                        return;
                    case "4":
                        HospitalOption4();
                        return;
                    case "5":
                        break;
                    default:
                        Menu.DisplayErrorInput("Invalid input. Please enter from 1 - 5: ");
                        option = Console.ReadLine();
                        break;
                }
            } while (option != "5");

        }

        public void VisitHandler(ref string option)
        {
            do
            {
                switch (option)
                {
                    case "1":
                        VisitOption1();
                        return;
                    case "2":
                        VisitOption2();
                        return;
                    case "3":
                        VisitOption3();
                        return;
                    case "4":
                        VisitOption4();
                        return;
                    case "5":
                        break;
                    default:
                        Menu.DisplayErrorInput("Invalid input. Please enter from 1 - 5: ");
                        option = Console.ReadLine();
                        break;
                }
            } while (option != "5");

        }

        private void DoctorOption1()
        {
            Console.WriteLine();
            Console.Write("Enter doctor's name: ");
            string doctorname = Console.ReadLine();
            Console.Write("Enter doctor's date of birth(dd/mm/yyyy): ");
            string doctordob = Console.ReadLine();
            Console.Write("Enter doctor's license number: ");
            string license = Console.ReadLine();
            Console.Write("Enter doctor's address: ");
            string address = Console.ReadLine();
            Doctor newdoc = new Doctor(doctorname, doctordob, license, address);
            doctormanager.Create(newdoc);
            Console.WriteLine("<====== Doctor added ======>\n");
        }

        private void DoctorOption2()
        {
            Console.Write("Enter doctor's id: ");
            string doctorsearch = Console.ReadLine();
            try
            {
                Doctor doctorfound = doctormanager.Read(doctorsearch);
                Console.WriteLine("Doctor's id: " + doctorfound.Id);

                Console.WriteLine("Doctor's name: " + doctorfound.Name);
                Console.Write("Update doctor's name: ");
                string newDocName = Console.ReadLine();
                doctorfound.Name = newDocName;

                Console.WriteLine("Doctor's date of birth: " + doctorfound.Dob);
                Console.Write("Update doctor's date of birth: ");
                string newDocDob = Console.ReadLine();
                doctorfound.Dob = newDocDob;

                Console.WriteLine("Doctor's license: " + doctorfound.LicenseNumber);
                Console.Write("Update doctor's license number: ");
                string newDocLicense = Console.ReadLine();
                doctorfound.LicenseNumber = newDocLicense;

                Console.WriteLine("<====== Doctor updated ======>\n");

            }
            catch (InvalidDoctorsInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void DoctorOption3()
        {
            Console.Write("Enter doctor's id: ");
            string doctorsearch = Console.ReadLine();
            try
            {
                Doctor doctorfound = doctormanager.Read(doctorsearch);
                doctormanager.Delete(doctorfound.Id);
                Console.WriteLine("<====== Doctor deleted ======>");
            }
            catch (InvalidDoctorsInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void DoctorOption4()
        {
            Console.WriteLine();
            doctormanager.GetAllRecords();
            Console.WriteLine();

        }

        private void PatientOption1()
        {
            Console.WriteLine();
            Console.Write("Enter patient's name: ");
            string patientname = Console.ReadLine();
            Console.Write("Enter patient's date of birth(dd/mm/yyyy): ");
            string patientdob = Console.ReadLine();
            Console.Write("Enter patient's gender(m/f):  ");
            string gender = Console.ReadLine().ToLower();
            Console.Write("Enter patient's address: ");
            string address = Console.ReadLine();
            Patient newpa = new Patient(patientname, gender, patientdob, address);
            patientmanager.Create(newpa);
            Console.WriteLine("<====== Patient added ======>\n");

        }

        private void PatientOption2()
        {
            Console.Write("Enter patient's id: ");
            string patientsearch = Console.ReadLine();
            try
            {
                Patient patientfound = patientmanager.Read(patientsearch);
                Console.WriteLine("Patient's id: " + patientfound.Id);

                Console.WriteLine("Patient's name: " + patientfound.Name);
                Console.Write("Update patient's name: ");
                string newPaName = Console.ReadLine();
                patientfound.Name = newPaName;

                Console.WriteLine("Patient's date of birth: " + patientfound.Dob);
                Console.Write("Update patient's date of birth: ");
                string newPaDob = Console.ReadLine();
                patientfound.Dob = newPaDob;

                Console.WriteLine("Patient's gender: " + patientfound.Gender);
                Console.Write("Update patient's gender: ");
                string newPaGender = Console.ReadLine();
                patientfound.Gender = newPaGender;

                Console.WriteLine("Patient's address: " + patientfound.Address);
                Console.Write("Update patient's address: ");
                string newPaAddress = Console.ReadLine();
                patientfound.Gender = newPaAddress;

                Console.WriteLine("<====== Patient updated ======>\n");

            }
            catch (InvalidPatientsInformationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PatientOption3()
        {
            Console.Write("Enter patient's id: ");
            string patientsearch = Console.ReadLine();
            try
            {
                Patient patientfound = patientmanager.Read(patientsearch);
                patientmanager.Delete(patientfound.Id);
                Console.WriteLine("<====== Patient deleted ======>");
            }
            catch (InvalidPatientsInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void PatientOption4()
        {
            Console.WriteLine();
            patientmanager.GetAllRecords();
            Console.WriteLine();

        }

        private void HospitalOption1()
        {
            Console.WriteLine();
            Console.Write("Enter hospital's name: ");
            string hospitalName = Console.ReadLine();
            Console.Write("Enter hospital's license number: ");
            string hospitalLicense = Console.ReadLine();
            Console.Write("Enter hospital's address: ");
            string address = Console.ReadLine();
            Hospital newhos = new Hospital(hospitalName, hospitalLicense, address);
            hospitalmanager.Create(newhos);
            Console.WriteLine("<====== Hospital added ======>\n");

        }

        private void HospitalOption2()
        {
            Console.Write("Enter hospital's id: ");
            string hospitalsearch = Console.ReadLine();
            try
            {
                Hospital hospitalfound = hospitalmanager.Read(hospitalsearch);
                Console.WriteLine("Hospital's id: " + hospitalfound.Id);

                Console.WriteLine("Hospital's name: " + hospitalfound.Name);
                Console.Write("Update hospital's name: ");
                string newHosName = Console.ReadLine();
                hospitalfound.Name = newHosName;

                Console.WriteLine("Hospital's license number: " + hospitalfound.LicenseNumber);
                Console.Write("Update hospital's license number: ");
                string newHosLicense = Console.ReadLine();
                hospitalfound.LicenseNumber = newHosLicense;

                Console.WriteLine("Hospital's address: " + hospitalfound.Address);
                Console.Write("Update hospital's address: ");
                string newHosAddress = Console.ReadLine();
                hospitalfound.Address = newHosAddress;

                Console.WriteLine("<====== Hospital updated ======>\n");

            }
            catch (InvalidHospitalInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void HospitalOption3()
        {
            Console.Write("Enter hospital's id: ");
            string hospitalsearch = Console.ReadLine();
            try
            {
                Hospital hospitalfound = hospitalmanager.Read(hospitalsearch);
                hospitalmanager.Delete(hospitalfound.Id);
                Console.WriteLine("<====== Hospital deleted ======>");
            }
            catch (InvalidHospitalInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void HospitalOption4()
        {
            Console.WriteLine();
            hospitalmanager.GetAllRecords();
            Console.WriteLine();

        }

        private void VisitOption1()
        {
            Console.WriteLine();
            try
            {
                Console.Write("Enter patient's id: ");
                Patient visitPatient = patientmanager.Read(Console.ReadLine());
                Console.Write("Enter doctor's id: ");
                Doctor visitDoctor = doctormanager.Read(Console.ReadLine());

                Console.Write("Enter treated date(dd/mm/yyyy): ");
                string treatedDate = Console.ReadLine();
                Console.Write("Enter place: ");
                string place = Console.ReadLine();
                Console.Write("Enter Diagnosis: ");
                string diagnosis = Console.ReadLine();
                Console.Write("Enter outcome: ");
                string outcome = Console.ReadLine();

                Visit newvis = new Visit(treatedDate, place, visitPatient, visitDoctor, diagnosis, outcome);
                visitmanager.Create(newvis);

                Console.WriteLine("<====== Visit added ======>\n");

            }
            catch (InvalidPatientsInformationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidDoctorsInformationException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        private void VisitOption2()
        {
            Console.Write("Enter visit's id: ");
            string visitsearch = Console.ReadLine();
            try
            {
                Visit visitfound = visitmanager.Read(visitsearch);
                Console.WriteLine("Visit's id: " + visitfound.Id);

                Console.WriteLine("Patient's id: " + visitfound.TreatedPatient.Id);
                Console.Write("Update patient's id: ");
                Patient visitPatient = patientmanager.Read(Console.ReadLine());
                visitfound.TreatedPatient = visitPatient;

                Console.WriteLine("Doctor's id: " + visitfound.TreatingDoctor.Id);
                Console.Write("Update doctor's id: ");
                Doctor visitDoctor = doctormanager.Read(Console.ReadLine());
                visitfound.TreatingDoctor = visitDoctor;

                Console.WriteLine("Visit date: " + visitfound.TreatedDate);
                Console.Write("Update visit date(dd/mm/yyyy): ");
                string newVisitDate = Console.ReadLine();
                visitfound.TreatedDate = newVisitDate;

                Console.WriteLine("Visit place: " + visitfound.Place);
                Console.Write("Update visit place: ");
                string newVisitPlace = Console.ReadLine();
                visitfound.Place = newVisitPlace;

                Console.WriteLine("Visit diagnosis: " + visitfound.Diagnosis);
                Console.Write("Update diagnosis: ");
                string newVisitDiagnosis = Console.ReadLine();
                visitfound.Diagnosis = newVisitDiagnosis;

                Console.WriteLine("Visit outcome: " + visitfound.Outcome);
                Console.Write("Update outcome: ");
                string newVisitOutcome = Console.ReadLine();
                visitfound.Outcome = newVisitOutcome;

                Console.WriteLine("<====== Visit updated ======>\n");

            }
            catch (InvalidVisitInformationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidPatientsInformationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidDoctorsInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void VisitOption3()
        {
            Console.Write("Enter visit's id: ");
            string visitsearch = Console.ReadLine();
            try
            {
                Visit visitfound = visitmanager.Read(visitsearch);
                visitmanager.Delete(visitfound.Id);
                Console.WriteLine("<====== Visit deleted ======>");
            }
            catch (InvalidVisitInformationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void VisitOption4()
        {
            Console.WriteLine();
            visitmanager.GetAllRecords();
            Console.WriteLine();
        }
    }
}
