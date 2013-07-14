using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpenHIA.Ultility
{
    class DataValidation
    {
        public bool CheckDate(string date)
        {
            var datePattern = @"^[0-9]{2}/[0-9]{2}/[0-9]{4}$";
            var exp = new Regex(datePattern);
            int currentYear = DateTime.Now.Year;

            if (!exp.IsMatch(date))
            {
                return false;
            }

            int day = Convert.ToInt32(date.Substring(0, 2));
            int month = Convert.ToInt32(date.Substring(3, 2));
            int year = Convert.ToInt32(date.Substring(6));
            
            if (day < 0 || day > 31)
            {
                return false;
            }
            else if (month < 0 || month > 12)
            {
                return false;
            }
            else if (year < 1850 || year > currentYear)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckOutCome(string outcome)
        {
            string[] outcomeList = new string[]{"CURED","DECREASED","INCREASED","UNCHANGED","DIED"};
            if (compareListOption(outcome, outcomeList))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckGender(string gender)
        {
            if (gender.Equals("m") || gender.Equals("f"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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


    }
}
