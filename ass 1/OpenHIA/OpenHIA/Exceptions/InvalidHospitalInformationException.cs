using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Exceptions
{
    class InvalidHospitalInformationException : Exception
    {
        public InvalidHospitalInformationException(string msg)
            : base(msg)
        {

        }
    }
}
