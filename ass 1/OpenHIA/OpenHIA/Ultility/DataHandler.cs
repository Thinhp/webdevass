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
        private DoctorCrud doctorManager = new DoctorCrud();
        private PatientCrud patientManager = new PatientCrud();
        private HospitalCrud hospitalManager = new HospitalCrud();
        private VisitCrud visitManager = new VisitCrud();

        private DataValidation datavalidation = new DataValidation();

        public DoctorCrud DoctorManager
        {
            get { return doctorManager; }
            set { this.doctorManager = value; }
        }

        public PatientCrud PatientManager
        {
            get { return patientManager; }
            set { this.patientManager = value; }
        }

        public HospitalCrud HospitalManager
        {
            get { return hospitalManager; }
            set { this.hospitalManager = value; }
        }

        public VisitCrud VisitManager
        {
            get { return visitManager; }
            set { this.visitManager = value; }
        }

        public DataValidation DataValidation
        {
            get { return datavalidation; }
            set { this.datavalidation = value; }
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
            if (datavalidation.CheckName(doctorname) == false)
            {
                Console.WriteLine("Please type correct name format\n");
                return;
            }

            Console.Write("Enter doctor's date of birth(dd/mm/yyyy): ");
            string doctordob = Console.ReadLine();
            if (datavalidation.CheckDate(doctordob) == false)
            {
                Console.WriteLine("Please type in format (dd/mm/yyyy)\n");
                return;
            }

            Console.Write("Enter doctor's license number: ");
            string license = Console.ReadLine();
            Console.Write("Enter doctor's address: ");
            string address = Console.ReadLine();
            Doctor newdoc = new Doctor(doctorname, doctordob, license, address);
            doctorManager.Create(newdoc);
            Console.WriteLine("<====== Doctor added ======>\n");
        }

        private void DoctorOption2()
        {
            Console.Write("Enter doctor's id: ");
            string doctorsearch = Console.ReadLine();
            try
            {
                Doctor doctorfound = doctorManager.Read(doctorsearch);
                Console.WriteLine("Doctor's id: " + doctorfound.Id);

                Console.WriteLine("Doctor's name: " + doctorfound.Name);
                Console.Write("Update doctor's name: ");
                string newDocName = Console.ReadLine();
                if (datavalidation.CheckName(newDocName) == false)
                {
                    Console.WriteLine("Please type correct name format\n");
                    return;
                }

                Console.WriteLine("Doctor's date of birth: " + doctorfound.Dob);
                Console.Write("Update doctor's date of birth: ");
                string newDocDob = Console.ReadLine();
                if (datavalidation.CheckDate(newDocDob) == false)
                {
                    Console.WriteLine("Please type in format (dd/mm/yyyy)\n");
                    return;
                }

                Console.WriteLine("Doctor's license: " + doctorfound.LicenseNumber);
                Console.Write("Update doctor's license number: ");
                string newDocLicense = Console.ReadLine();

                doctorfound.Name = newDocName;
                doctorfound.LicenseNumber = newDocLicense;
                doctorfound.Dob = newDocDob;
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
                Doctor doctorfound = doctorManager.Read(doctorsearch);
                doctorManager.Delete(doctorfound.Id);
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
            doctorManager.GetAllRecords();
            Console.WriteLine();

        }

        private void PatientOption1()
        {
            Console.WriteLine();
            Console.Write("Enter patient's name: ");
            string patientname = Console.ReadLine();
            Console.Write("Enter patient's date of birth(dd/mm/yyyy): ");
            string patientdob = Console.ReadLine();
            if (datavalidation.CheckDate(patientdob) == false)
            {
                Console.WriteLine("Please type in format (dd/mm/yyyy)\n");
                return;
            }
            Console.Write("Enter patient's gender(m/f):  ");
            string gender = Console.ReadLine().ToLower();
            if (datavalidation.CheckGender(gender) == false)
            {
                Console.WriteLine("Please type either 'm' or 'f'\n");
                return;
            }

            if (gender.Equals("m"))
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            Console.Write("Enter patient's address: ");
            string address = Console.ReadLine();
            Patient newpa = new Patient(patientname, gender, patientdob, address);
            patientManager.Create(newpa);
            Console.WriteLine("<====== Patient added ======>\n");

        }

        private void PatientOption2()
        {
            Console.Write("Enter patient's id: ");
            string patientsearch = Console.ReadLine();
            try
            {
                Patient patientfound = patientManager.Read(patientsearch);
                Console.WriteLine("Patient's id: " + patientfound.Id);

                Console.WriteLine("Patient's name: " + patientfound.Name);
                Console.Write("Update patient's name: ");
                string newPaName = Console.ReadLine();
                if (datavalidation.CheckName(newPaName) == false)
                {
                    Console.WriteLine("Please type correct name format\n");
                    return;
                }

                Console.WriteLine("Patient's date of birth: " + patientfound.Dob);
                Console.Write("Update patient's date of birth: ");
                string newPaDob = Console.ReadLine();
                if (datavalidation.CheckDate(newPaDob) == false)
                {
                    Console.WriteLine("Please type in format (dd/mm/yyyy)\n");
                    return;
                }

                Console.WriteLine("Patient's gender: " + patientfound.Gender);
                Console.Write("Update patient's gender: ");
                string newPaGender = Console.ReadLine();
                if (datavalidation.CheckGender(newPaGender) == false)
                {
                    Console.WriteLine("Please type either 'm' or 'f'\n");
                    return;
                }

                if (newPaGender.Equals("m"))
                {
                    newPaGender = "male";
                }
                else
                {
                    newPaGender = "female";
                }

                Console.WriteLine("Patient's address: " + patientfound.Address);
                Console.Write("Update patient's address: ");
                string newPaAddress = Console.ReadLine();

                patientfound.Name = newPaName;
                patientfound.Gender = newPaAddress;
                patientfound.Gender = newPaGender;
                patientfound.Dob = newPaDob;
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
                Patient patientfound = patientManager.Read(patientsearch);
                patientManager.Delete(patientfound.Id);
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
            patientManager.GetAllRecords();
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
            hospitalManager.Create(newhos);
            Console.WriteLine("<====== Hospital added ======>\n");

        }

        private void HospitalOption2()
        {
            Console.Write("Enter hospital's id: ");
            string hospitalsearch = Console.ReadLine();
            try
            {
                Hospital hospitalfound = hospitalManager.Read(hospitalsearch);
                Console.WriteLine("Hospital's id: " + hospitalfound.Id);

                Console.WriteLine("Hospital's name: " + hospitalfound.Name);
                Console.Write("Update hospital's name: ");
                string newHosName = Console.ReadLine();

                Console.WriteLine("Hospital's license number: " + hospitalfound.LicenseNumber);
                Console.Write("Update hospital's license number: ");
                string newHosLicense = Console.ReadLine();

                Console.WriteLine("Hospital's address: " + hospitalfound.Address);
                Console.Write("Update hospital's address: ");
                string newHosAddress = Console.ReadLine();

                hospitalfound.Name = newHosName;
                hospitalfound.Address = newHosAddress;
                hospitalfound.LicenseNumber = newHosLicense;
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
                Hospital hospitalfound = hospitalManager.Read(hospitalsearch);
                hospitalManager.Delete(hospitalfound.Id);
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
            hospitalManager.GetAllRecords();
            Console.WriteLine();

        }

        private void VisitOption1()
        {
            Console.WriteLine();
            try
            {
                Console.Write("Enter patient's id: ");
                Patient visitPatient = patientManager.Read(Console.ReadLine());
                Console.Write("Enter doctor's id: ");
                Doctor visitDoctor = doctorManager.Read(Console.ReadLine());
                Console.Write("Enter hospital's name or id: ");
                Hospital visitHospital = hospitalManager.Read(Console.ReadLine());

                Console.Write("Enter treated date(dd/mm/yyyy): ");
                string treatedDate = Console.ReadLine();
                if (datavalidation.CheckDate(treatedDate) == false)
                {
                    Console.WriteLine("Please type in format (dd/mm/yyyy)\n");
                    return;
                }
                Console.Write("Enter Diagnosis: ");
                string diagnosis = Console.ReadLine();
                Console.Write("Enter outcome: ");
                string outcome = Console.ReadLine().ToUpper();
                if (datavalidation.CheckOutCome(outcome) == false)
                {
                    Console.WriteLine("Outcome must be 'CURED','DECREASED','INCREASED','UNCHANGED','DIED'\n");
                    return;
                }

                Visit newvis = new Visit(treatedDate, visitHospital, visitPatient, visitDoctor, diagnosis, outcome);
                visitManager.Create(newvis);

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
            catch (InvalidHospitalInformationException e)
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
                Visit visitfound = visitManager.Read(visitsearch);
                Console.WriteLine("Visit's id: " + visitfound.Id);

                Console.WriteLine("Patient's id: " + visitfound.TreatedPatient.Id);
                Console.Write("Update patient's id: ");
                Patient visitPatient = patientManager.Read(Console.ReadLine());

                Console.WriteLine("Doctor's id: " + visitfound.TreatingDoctor.Id);
                Console.Write("Update doctor's id: ");
                Doctor visitDoctor = doctorManager.Read(Console.ReadLine());

                Console.WriteLine("Hospital's id: " + visitfound.Place.Id);
                Console.WriteLine("Hospital's name: " + visitfound.Place.Name);
                Console.Write("Update hospital's by either name or id: ");
                Hospital visitHospital = hospitalManager.Read(Console.ReadLine());

                Console.WriteLine("Visit date: " + visitfound.TreatedDate);
                Console.Write("Update visit date(dd/mm/yyyy): ");
                string newVisitDate = Console.ReadLine();

                Console.WriteLine("Visit diagnosis: " + visitfound.Diagnosis);
                Console.Write("Update diagnosis: ");
                string newVisitDiagnosis = Console.ReadLine();

                Console.WriteLine("Visit outcome: " + visitfound.Outcome);
                Console.Write("Update outcome: ");
                string newVisitOutcome = Console.ReadLine().ToUpper();

                if (datavalidation.CheckOutCome(newVisitOutcome) == false)
                {
                    Console.WriteLine("Outcome must be 'CURED','DECREASED','INCREASED','UNCHANGED','DIED'");
                    return;
                }

                visitfound.TreatingDoctor = visitDoctor;
                visitfound.TreatedPatient = visitPatient;
                visitfound.Outcome = newVisitOutcome;
                visitfound.Diagnosis = newVisitDiagnosis;
                visitfound.TreatedDate = newVisitDate;
                visitfound.Place = visitHospital;
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
                Visit visitfound = visitManager.Read(visitsearch);
                visitManager.Delete(visitfound.Id);
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
            visitManager.GetAllRecords();
            Console.WriteLine();
        }

        public void PopulateSampleData()
        {
            Doctor sam1 = new Doctor("Sam", "03/08/1993", "AB345AD", "123 Vinh Hung");
            Doctor sam2 = new Doctor("Mike", "08/03/1998", "CD34EAC", "3/2 Truong Chinh");
            doctorManager.Create(sam1);
            doctorManager.Create(sam2);

            Patient sam3 = new Patient("Hung", "male", "18/9/1990", "345 CMT8");
            Patient sam4 = new Patient("Minh", "female", "10/10/1991", "2A Vuong Trieu");
            patientManager.Create(sam3);
            patientManager.Create(sam4);

            Hospital sam5 = new Hospital("Thong Nhat", "3GHE29", "111 DBT");
            Hospital sam6 = new Hospital("Cho Ray", "GH54K3", "333 Ban Co");
            hospitalManager.Create(sam5);
            hospitalManager.Create(sam6);

            Visit sam7 = new Visit("11/11/2011", sam5, sam3, sam1, "ICD98", "CURED");
            visitManager.Create(sam7);

        }
    }
}
