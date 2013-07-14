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

        }

        private void HospitalOption2()
        {

        }

        private void HospitalOption3()
        {

        }

        private void HospitalOption4()
        {

        }

        private void VisitOption1()
        {

        }

        private void VisitOption2()
        {

        }

        private void VisitOption3()
        {

        }

        private void VisitOption4()
        {

        }
    }
}
