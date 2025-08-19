using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspProj
{
  
    
        public class ElectricityBill
        {
            private string consumerNumber;
          

            public string ConsumerNumber
            {
                get { return consumerNumber; }
                set
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^EB\d{5}$"))
                        throw new FormatException("Invalid Consumer Number");
                    consumerNumber = value;
                }
            }

            public string ConsumerName { get; set; }
            public int UnitsConsumed { get; set; }
            public double BillAmount { get; set; }
        }

    }
