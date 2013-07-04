using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Exceptions
{
    class InvalidPatientsInformationException : Exception
    {
        public InvalidPatientsInformationException(string msg) 
            : base(msg) 
        { 
        
        }
    }
}
