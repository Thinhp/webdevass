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
            string hosname = "AB";
            string hoslicense = "12BADWA";
            string hosaddress = "123 abc";
            Hospital newhos = new Hospital(hosname, hoslicense, hosaddress);
            hosCrud.Create(newhos);
            if (Database.HospitalList.Count > count)
            {
                currentPassedTest++;
                Console.WriteLine("Hospital option 1 passed - Can create hospital [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Hospital option 1 failed - Cannot create hospital[0/1]");
            }

            totalTest++;
        }

        public void TestHospitalOption2()
        {
            HospitalCrud hosCrud = new HospitalCrud();
            string hosname = "AB";
            string hoslicense = "12BADWA";
            string hosaddress = "123 abc";
            Hospital newhos = new Hospital(hosname, hoslicense, hosaddress);
            hosCrud.Create(newhos);

            Hospital hosRead = hosCrud.Read(newhos.Id);
            hosRead.Name = "new AB";
            hosRead.LicenseNumber = "NEW12BAD";
            hosRead.Address = "123 new";

            int checkName = String.Compare(hosname, hosRead.Name); 
            int checkLicense = String.Compare(hoslicense, hosRead.LicenseNumber); 
            int checkAddress = String.Compare(hosaddress, hosRead.Address);

            if (!(checkName == 0 && checkLicense == 0 && checkAddress == 0))
            {
                currentPassedTest++;
                Console.WriteLine("Hospital option 2 passed - Can edit hospital [1/1]");
            }else{
                currentFailedTest++;
                Console.WriteLine("Hospital option 2 failed - Cannot edit hospital [0/1]");
            }

            totalTest++;
        }

        public void TestHospitalOption3()
        {
            HospitalCrud hosCrud = new HospitalCrud();
            string hosname = "AB";
            string hoslicense = "12BADWA";
            string hosaddress = "123 abc";
            Hospital newhos = new Hospital(hosname, hoslicense, hosaddress);
            hosCrud.Create(newhos);

            int count = Database.HospitalList.Count;

            hosCrud.Delete(newhos.Id);

            if (Database.HospitalList.Count < count)
            {
                currentPassedTest++;
                Console.WriteLine("Hospital option 3 passed - Can delete hospital [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Hospital option 3 failed - Cannot delete hospital [0/1]");
            }
        }

        public void TestVisitOption1()
        {
            int count = Database.VisitList.Count;

            DoctorCrud docCrud = new DoctorCrud();
            string docname = "AB";
            string docdob = "19/02/1992";
            string doclicense = "12BADWA";
            string docaddress = "123 abc";
            Doctor newdoc = new Doctor(docname, docdob, doclicense, docaddress);
            docCrud.Create(newdoc);

            PatientCrud patientCrud = new PatientCrud();
            string patientName = "AB";
            string patientGender = "male";
            string patientDob = "12/03/1992";
            string patientAddress = "123 abc";
            Patient newPa = new Patient(patientName,patientGender,patientDob , patientAddress);
            patientCrud.Create(newPa);

            HospitalCrud hosCrud = new HospitalCrud();
            string hosname = "AB";
            string hoslicense = "12BADWA";
            string hosaddress = "123 abc";
            Hospital newhos = new Hospital(hosname, hoslicense, hosaddress);
            hosCrud.Create(newhos);

            VisitCrud visCrud = new VisitCrud();
            string date = "19/02/1992";
            string diagnosis = "ICD89";
            string outcome = "CURED";
            Visit newvis = new Visit(date,newhos,newPa,newdoc,diagnosis,outcome);
            visCrud.Create(newvis);
            if (Database.VisitList.Count > count)
            {
                currentPassedTest++;
                Console.WriteLine("Visit option 1 passed - Can create visit [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Visit option 1 failed - Cannot create visit [0/1]");
            }

            totalTest++;
        }

        public void TestVisitOption2()
        {
            DoctorCrud docCrud = new DoctorCrud();
            string docname = "AB";
            string docdob = "19/02/1992";
            string doclicense = "12BADWA";
            string docaddress = "123 abc";
            Doctor newdoc = new Doctor(docname, docdob, doclicense, docaddress);
            docCrud.Create(newdoc);

            PatientCrud patientCrud = new PatientCrud();
            string patientName = "AB";
            string patientGender = "male";
            string patientDob = "12/03/1992";
            string patientAddress = "123 abc";
            Patient newPa = new Patient(patientName,patientGender,patientDob , patientAddress);
            patientCrud.Create(newPa);

            HospitalCrud hosCrud = new HospitalCrud();
            string hosname = "AB";
            string hoslicense = "12BADWA";
            string hosaddress = "123 abc";
            Hospital newhos = new Hospital(hosname, hoslicense, hosaddress);
            hosCrud.Create(newhos);

            VisitCrud visCrud = new VisitCrud();
            string date = "19/02/1992";
            string diagnosis = "ICD89";
            string outcome = "CURED";
            Visit newvis = new Visit(date,newhos,newPa,newdoc,diagnosis,outcome);
            visCrud.Create(newvis);

            Visit visitRead = visCrud.Read(newvis.Id);
            visitRead.TreatedPatient = new Patient("A", "male", "20/02/1993", "123 ABC");
            visitRead.TreatingDoctor = new Doctor ("A", "20/02/1993", "2R3TG","123 ABC");
            visitRead.Place = new Hospital("A", "97GT3", "123 ABC");
            visitRead.TreatedDate = "19/02/2003";
            visitRead.Diagnosis = "ICD33";
            visitRead.Outcome = "DIED";

            int checkDate = String.Compare(date, visitRead.TreatedDate); 
            int checkDiagnosis = String.Compare(diagnosis, visitRead.Diagnosis); 
            int checkOutcome = String.Compare(outcome, visitRead.Outcome);

            if (!(checkDate == 0 && checkDiagnosis == 0 && checkOutcome == 0))
            {
                currentPassedTest++;
                Console.WriteLine("Visit option 2 passed - Can edit visit [1/1]");
            }else{
                currentFailedTest++;
                Console.WriteLine("Visit option 2 failed - Cannot edit visit [0/1]");
            }

            totalTest++;
        }

        public void TestVisitOption3()
        {
            DoctorCrud docCrud = new DoctorCrud();
            string docname = "AB";
            string docdob = "19/02/1992";
            string doclicense = "12BADWA";
            string docaddress = "123 abc";
            Doctor newdoc = new Doctor(docname, docdob, doclicense, docaddress);
            docCrud.Create(newdoc);

            PatientCrud patientCrud = new PatientCrud();
            string patientName = "AB";
            string patientGender = "male";
            string patientDob = "12/03/1992";
            string patientAddress = "123 abc";
            Patient newPa = new Patient(patientName,patientGender,patientDob , patientAddress);
            patientCrud.Create(newPa);

            HospitalCrud hosCrud = new HospitalCrud();
            string hosname = "AB";
            string hoslicense = "12BADWA";
            string hosaddress = "123 abc";
            Hospital newhos = new Hospital(hosname, hoslicense, hosaddress);
            hosCrud.Create(newhos);

            VisitCrud visCrud = new VisitCrud();
            string date = "19/02/1992";
            string diagnosis = "ICD89";
            string outcome = "CURED";
            Visit newvis = new Visit(date,newhos,newPa,newdoc,diagnosis,outcome);
            visCrud.Create(newvis);

            int count = Database.VisitList.Count;

            visCrud.Delete(newvis.Id);

            if (Database.VisitList.Count < count)
            {
                currentPassedTest++;
                Console.WriteLine("Visit option 3 passed - Can delete visit [1/1]");
            }
            else
            {
                currentFailedTest++;
                Console.WriteLine("Visit option 3 failed - Cannot delete visit [0/1]");
            }
        }

        public void TestCheckDate()
        {
            DataValidation datavalidation = new DataValidation();
            string validDate = "28/02/1992";
            string invalidDate1 = "28/2/1992";
            string invalidDate2 = "abcde";
            string invalidDate3 = "32/99/2014";

            bool valid1 = datavalidation.CheckDate(validDate);
            bool invalid1 = datavalidation.CheckDate(invalidDate1);
            bool invalid2 = datavalidation.CheckDate(invalidDate2);
            bool invalid3 = datavalidation.CheckDate(invalidDate3);

            if (valid1 && !invalid1 && !invalid2 && !invalid3)
            {
                currentPassedTest++;
                Console.WriteLine("Test Check Date validation passed [1/1]");
            }
            else
            {
                CurrentFailedTest++;
                Console.WriteLine("Test Check Date validation failed [0/1]");
            }
            totalTest++;
        }

        public void TestCheckOutcome()
        {
            DataValidation datavalidation = new DataValidation();
            string valid1 = "CURED";
            string valid2 = "INCREASED";
            string invalid1 = "HEALTHY";
            string invalid2 = "GONE";

            bool test1 = datavalidation.CheckOutCome(valid1);
            bool test2 = datavalidation.CheckOutCome(valid2);
            bool test3 = datavalidation.CheckOutCome(invalid1);
            bool test4 = datavalidation.CheckOutCome(invalid2);

            if(test1 && test2 && !test3 && !test4){
                currentPassedTest++;
                Console.WriteLine("Test check outcome passed [1/1]");
            }else{
                currentFailedTest++;
                Console.WriteLine("Test check outcome failed [0/1]");
            }
            totalTest++;
        }

        public void TestCheckGender()
        {
            DataValidation datavalidation = new DataValidation();
            string valid1 = "m";
            string valid2 = "f";
            string invalid1 = "boy";
            string invalid2 = "girl";

            bool test1 = datavalidation.CheckGender(valid1);
            bool test2 = datavalidation.CheckGender(valid2);
            bool test3 = datavalidation.CheckGender(invalid1);
            bool test4 = datavalidation.CheckGender(invalid2);

            if (test1 && test2 && !test3 && !test4)
            {
                currentPassedTest++;
                Console.WriteLine("Test check gender passed [1/1]");
            }
            else
            {
                CurrentFailedTest++;
                Console.WriteLine("Test check gender failed [0/1]");
            }
            totalTest++;
        }

        public void TestCheckName()
        {
            DataValidation datavalidation = new DataValidation();
            string valid1 = "Tuan Anh";
            string valid2 = "Mike Sao";
            string invalid1 = "Cuong123";
            string invalid2 = "!@#$@";

            bool test1 = datavalidation.CheckName(valid1);
            bool test2 = datavalidation.CheckName(valid2);
            bool test3 = datavalidation.CheckName(invalid1);
            bool test4 = datavalidation.CheckName(invalid2);

            if (test1 && test2 && !test3 && !test4)
            {
                currentPassedTest++;
                Console.WriteLine("Test check name passed [1/1]");
            }
            else
            {
                CurrentFailedTest++;
                Console.WriteLine("Test check name failed [0/1]");
            }
            totalTest++;
        }
    }
}
