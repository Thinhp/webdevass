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

        public void DoctorHandler(string option)
        {
            do
            {

                switch (option)
                {
                    case "1":
                        DoctorOption1();
                        option = "5";
                        break;
                    case "2":
                        DoctorOption2();
                        option = "5";
                        break;
                    case "3":
                        DoctorOption3();
                        option = "5";
                        break;
                    case "4":
                        DoctorOption4();
                        option = "5";
                        break;
                    case "5":
                        break;
                    default:
                        Menu.DisplayErrorInput("Invalid input. Please enter from 1 - 5: ");
                        option = Console.ReadLine();
                        break;
                }
            } while (option != "5");
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

        private void DoctorOption1()
        {
            Console.WriteLine();
            Console.Write("Enter doctor's name: ");
            string doctorname = Console.ReadLine();
            Console.Write("Enter doctor's Date of birth(dd/mm/yyyy): ");
            string doctordob = Console.ReadLine();
            Console.Write("Enter doctor's license number: ");
            string license = Console.ReadLine();
            Console.Write("Enter doctor's address: ");
            string address = Console.ReadLine();
            Doctor newdoc = new Doctor(doctorname, doctordob, license, address);
            doctormanager.Create(newdoc);
            Console.WriteLine("<====== Doctor created ======>\n");
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
                Console.WriteLine("Updated -> doctor's name: " + doctorfound.Name);

                Console.WriteLine("Doctor's date of birth: " + doctorfound.Dob);
                Console.Write("Update doctor's date of birth: ");
                string newDocDob = Console.ReadLine();
                doctorfound.Dob = newDocDob;
                Console.WriteLine("Updated -> doctor's date of birth: " + doctorfound.Dob);

                Console.WriteLine("Doctor's license: " + doctorfound.LicenseNumber);
                Console.Write("Update doctor's license number: ");
                string newDocLicense = Console.ReadLine();
                doctorfound.LicenseNumber = newDocLicense;
                Console.WriteLine("Updated -> doctor's license number: " + doctorfound.LicenseNumber);

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
                Console.WriteLine("Doctor deleted");
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
    }
}
