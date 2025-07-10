using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library4
{

        public class Liberary
        {
            public static string CalculateConcession(int age, double totalFare)
            {
                if (age <= 5)
                {
                    return "Little Champs - Free Ticket";
                }
                else if (age > 60)
                {
                    double discountedFare = totalFare * 0.7;
                    return $"Senior Citizen - Fare after concession: {discountedFare}";
                }
                else
                {
                    return $"Ticket Booked - Fare: {totalFare}";
                }
            }
        }

    }

