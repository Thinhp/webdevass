using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpenHIA.Ultility
{
    public class DataValidation
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
            string pattern = @"^CURED|DECREASED|INCREASED|UNCHANGED|DIED$";
            if (Regex.IsMatch(outcome, pattern))
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

        public bool CheckName(string name)
        {
            string pattern = @"^[a-zA-Z\ ]+$";
            if (Regex.IsMatch(name + "", pattern))
            {
                return true;
            }
            return false;
        }

    }
}
