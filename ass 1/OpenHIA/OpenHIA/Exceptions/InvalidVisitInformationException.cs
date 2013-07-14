using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Exceptions
{
    class InvalidVisitInformationException : Exception
    {
        public InvalidVisitInformationException(string msg)
            : base(msg)
        {

        }
    }
}
