using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspProj
{
    public class CnumberValidator
    {
        public string ValidateConsumer(string cno)

        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(cno, @"^EB\d{5}$"))
            
               
                     throw new FormatException("Invalid");
                             return cno;
               
            
        }

        internal static string ValidateCosumer(string cno)
        {
            throw new NotImplementedException();
        }

        //internal static string ValidateCosumer(int units)
        //{
        //    throw new NotImplementedException();
        //}
    }
}


//if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^EB\d{5}$"))