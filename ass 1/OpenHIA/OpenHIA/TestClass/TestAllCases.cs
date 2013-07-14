using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Model;
using OpenHIA.Service;
using OpenHIA.Program;
using OpenHIA.Ultility;

namespace OpenHIA.TestClass
{
    class TestAllCases
    {
        private int currentPassedTest = 0;
        private int currentFailedTest = 0;
        private int totalTest = 0;

        public int CurrentPassedTest
        {
            get { return currentPassedTest; }
            set { currentPassedTest = value; }
        }

        public int CurrentFailedTest
        {
            get { return currentFailedTest; }
            set { currentFailedTest = value; }
        }

        public int TotalTest
        {
            get { return totalTest; }
            set { totalTest = value; }
        }

        public void TestDoctorOption1()
        {
            int count = Database.DoctorList.Count;

            DoctorCrud docCrud = new DoctorCrud();
            string docname = "AB";
            string docdob = "19/02/1992";
            string doclicense = "12BADWA";
            string docaddress = "123 abc";
            Doctor newdoc = new Doctor(docname, docdob, doclicense, docaddress);
            docCrud.Create(newdoc);
            if (Database.DoctorList.Count > count)
            {
                currentPassedTest++;
                Console.WriteLine("Doctor option 1 passed - Can create doctor [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Doctor option 1 failed - Cannot create doctor[0/1]");
            }

            totalTest++;
        }

        public void TestDoctorOption2()
        {
            DoctorCrud docCrud = new DoctorCrud();
            string docName = "AB";
            string docDob = "19/02/1992";
            string docLicense = "12BADWA";
            string docAddress = "123 abc";
            Doctor newdoc = new Doctor(docName, docDob, docLicense, docAddress);
            docCrud.Create(newdoc);

            Doctor docRead = docCrud.Read(newdoc.Id);
            docRead.Name = "new AB";
            docRead.Dob = "29/02/1992";
            docRead.LicenseNumber = "NEW12BAD";
            docRead.Address = "123 new";

            int checkName = String.Compare(docName, docRead.Name); 
            int checkDob = String.Compare(docDob, docRead.Dob); 
            int checkLicense = String.Compare(docLicense, docRead.LicenseNumber); 
            int checkAddress = String.Compare(docAddress, docRead.Address);

            if (!(checkName == 0 && checkDob == 0 && checkLicense == 0 && checkAddress == 0))
            {
                currentPassedTest++;
                Console.WriteLine("Doctor option 2 passed - Can edit doctor [1/1]");
            }else{
                currentFailedTest++;
                Console.WriteLine("Doctor option 2 failed - Cannot edit doctor [0/1]");
            }

            totalTest++;
        }

        public void TestDoctorOption3()
        {
            DoctorCrud docCrud = new DoctorCrud();
            string docName = "AB";
            string docDob = "19/02/1992";
            string docLicense = "12BADWA";
            string docAddress = "123 abc";
            Doctor newdoc = new Doctor(docName, docDob, docLicense, docAddress);
            docCrud.Create(newdoc);

            int count = Database.DoctorList.Count;

            docCrud.Delete(newdoc.Id);

            if (Database.DoctorList.Count < count)
            {
                currentPassedTest++;
                Console.WriteLine("Doctor option 3 passed - Can delete doctor [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Doctor option 3 failed - Cannot delete doctor [0/1]");
            }
        }

        public void TestPatientOption1()
        {
            int count = Database.PatientList.Count;

            PatientCrud patientCrud = new PatientCrud();
            string patientName = "AB";
            string patientGender = "male";
            string patientDob = "12/03/1992";
            string patientAddress = "123 abc";
            Patient newPa = new Patient(patientName,patientGender,patientDob , patientAddress);
            patientCrud.Create(newPa);
            if (Database.PatientList.Count > count)
            {
                currentPassedTest++;
                Console.WriteLine("Patient option 1 passed");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Patient option 1 failed");
            }

            totalTest++;
        }

        public void TestPatientOption2()
        {
            PatientCrud patientCrud = new PatientCrud();
            string patientName = "AB";
            string patientDob = "19/02/1992";
            string patientGender = "male";
            string patientAddress = "123 abc";
            Patient newpa = new Patient(patientName, patientGender, patientDob, patientAddress);
            patientCrud.Create(newpa);

            Patient patientRead = patientCrud.Read(newpa.Id);
            patientRead.Name = "new AB";
            patientRead.Dob = "29/02/1992";
            patientRead.Gender = "female";
            patientRead.Address = "123 new";

            int checkName = String.Compare(patientName, patientRead.Name); 
            int checkDob = String.Compare(patientDob, patientRead.Dob); 
            int checkGender = String.Compare(patientGender, patientRead.Gender); 
            int checkAddress = String.Compare(patientAddress, patientRead.Address);

            if (!(checkName == 0 && checkDob == 0 && checkGender == 0 && checkAddress == 0))
            {
                currentPassedTest++;
                Console.WriteLine("Patient option 2 passed - Can edit patient [1/1]");
            }else{
                currentFailedTest++;
                Console.WriteLine("Patient option 2 failed - Cannot edit patient [0/1]");
            }

            totalTest++;
        }

        public void TestPatientOption3()
        {
            PatientCrud patientCrud = new PatientCrud();
            string patientName = "AB";
            string patientDob = "19/02/1992";
            string patientGender = "male";
            string patientAddress = "123 abc";
            Patient newpa = new Patient(patientName, patientGender, patientDob, patientAddress);
            patientCrud.Create(newpa);

            int count = Database.PatientList.Count;

            patientCrud.Delete(newpa.Id);

            if (Database.PatientList.Count < count)
            {
                currentPassedTest++;
                Console.WriteLine("Patient option 3 passed - Can delete patient [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Patient option 3 failed - Cannot delete patient [0/1]");
            }
        }

        public void TestHospitalOption1()
        {
            int count = Database.HospitalList.Count;

            HospitalCrud hosCrud = new HospitalCrud();
            string docname = "AB";
            string docdob = "19/02/1992";
            string doclicense = "12BADWA";
            string docaddress = "123 abc";
            Doctor newdoc = new Doctor(docname, docdob, doclicense, docaddress);
            hosCrud.Create(newdoc);
            if (Database.DoctorList.Count > count)
            {
                currentPassedTest++;
                Console.WriteLine("Doctor option 1 passed - Can create doctor [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Doctor option 1 failed - Cannot create doctor[0/1]");
            }

            totalTest++;
        }

        public void TestHospitalOption2()
        {
            DoctorCrud docCrud = new DoctorCrud();
            string docName = "AB";
            string docDob = "19/02/1992";
            string docLicense = "12BADWA";
            string docAddress = "123 abc";
            Doctor newdoc = new Doctor(docName, docDob, docLicense, docAddress);
            docCrud.Create(newdoc);

            Doctor docRead = docCrud.Read(newdoc.Id);
            docRead.Name = "new AB";
            docRead.Dob = "29/02/1992";
            docRead.LicenseNumber = "NEW12BAD";
            docRead.Address = "123 new";

            int checkName = String.Compare(docName, docRead.Name); 
            int checkDob = String.Compare(docDob, docRead.Dob); 
            int checkLicense = String.Compare(docLicense, docRead.LicenseNumber); 
            int checkAddress = String.Compare(docAddress, docRead.Address);

            if (!(checkName == 0 && checkDob == 0 && checkLicense == 0 && checkAddress == 0))
            {
                currentPassedTest++;
                Console.WriteLine("Doctor option 2 passed - Can edit doctor [1/1]");
            }else{
                currentFailedTest++;
                Console.WriteLine("Doctor option 2 failed - Cannot edit doctor [0/1]");
            }

            totalTest++;
        }

        public void TestHospitalOption3()
        {
            DoctorCrud docCrud = new DoctorCrud();
            string docName = "AB";
            string docDob = "19/02/1992";
            string docLicense = "12BADWA";
            string docAddress = "123 abc";
            Doctor newdoc = new Doctor(docName, docDob, docLicense, docAddress);
            docCrud.Create(newdoc);

            int count = Database.DoctorList.Count;

            docCrud.Delete(newdoc.Id);

            if (Database.DoctorList.Count < count)
            {
                currentPassedTest++;
                Console.WriteLine("Doctor option 3 passed - Can delete doctor [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Doctor option 3 failed - Cannot delete doctor [0/1]");
            }
        }
    }
}
