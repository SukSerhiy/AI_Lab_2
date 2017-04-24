using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2.Exceptions
{
    /// <summary>
    /// Throws when trying to parse uncorrect string to bool array
    /// </summary>
    class UncorrectStringForBoolParsingException : Exception
    {
        public new string Message = "Uncorrect value string value for parsing to bool array. Characters may be only '0' or '1'";
    }
}
