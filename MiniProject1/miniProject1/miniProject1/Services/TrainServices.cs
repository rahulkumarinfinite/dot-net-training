using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using miniProject1.REpo;
using miniProject1.Interface;

namespace miniProject1.Services
{
    class TrainServices :IAdmin,ICustomer
    {
        TrainRepo repo = new TrainRepo();

        public void ViewTrains()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("............................................................................................................");
            Console.ResetColor();
            repo.ViewTrains();
        }

        public void AddTrain()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();

                Console.Write("Enter Train Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Source: ");
                string source = Console.ReadLine();

                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();

                Console.Write("Enter Total Seats in FirstClass: ");
                int seats = int.Parse(Console.ReadLine());

                Console.Write("Enter Total Seats in Sleeper: ");
                int seats1 = int.Parse(Console.ReadLine());

                Console.Write("Enter Total Seats in AC: ");
                int seats2 = int.Parse(Console.ReadLine());

                Console.Write("Enter the BaseCost of train: ");
                float cost = int.Parse(Console.ReadLine());

                repo.AddTrain(name, source, destination, seats,seats1,seats2,cost);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Train successfully added.");
                Console.ResetColor();
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
        }

        public void DeleteTrain()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();

                Console.Write("Enter Train ID to delete: ");
                int trainId = int.Parse(Console.ReadLine());

                repo.DeleteTrain(trainId);

             
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message  + " "+ e.InnerException) ;
                Console.ResetColor();
            }
        }

        public void BookTicket()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();

                Console.Write("Enter Passenger Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                string phone = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Train ID: ");
                int trainId = int.Parse(Console.ReadLine());

                Console.Write("Enter Travel Date (yyyy-MM-dd): ");
                DateTime travelDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Class Type (Sleeper / AC / FirstClass):");
                string classType = Console.ReadLine();




                if (travelDate >= DateTime.Today)
                {
                    repo.BookTicket(name, phone, email, trainId, travelDate,classType);
                   
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Travel date should not be before the booking date.");
                    Console.ResetColor();
                }
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
        }

        public void CancelBooking()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();

                Console.Write("Enter Booking ID to cancel: ");
                int bookingId = int.Parse(Console.ReadLine());

                Console.Write("Enter Travel Date (yyyy-MM-dd): ");
                DateTime travelDate = DateTime.Parse(Console.ReadLine());

                repo.CancelTicket(bookingId, travelDate);

               
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
        }




        //

        public void ReservationReport()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();
                Console.WriteLine("Enter the starting Date(yyyy-mm-dd)");
                DateTime fromDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Ending Date(yyyy-mm-dd)");
                DateTime toDate = DateTime.Parse(Console.ReadLine());
                if (fromDate < toDate)
                {
                    repo.ReservationReport(fromDate, toDate);
                }
                else
                {
                    Console.WriteLine("Starting Date must be before the ending date");
                }
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
        }




        public void CancelReport()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();
                Console.WriteLine("Enter the starting Date(yyyy-mm-dd)");
                DateTime fromDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Ending Date(yyyy-mm-dd)");
                DateTime toDate = DateTime.Parse(Console.ReadLine());
                if (fromDate < toDate)
                {
                    repo.CancelReport(fromDate, toDate);
                }
                else
                {
                    Console.WriteLine("Starting Date must be before the ending date");
                }
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
        }







        public void UpdateTrain()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();

                Console.Write("Enter Train Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Train Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Source: ");
                string source = Console.ReadLine();

                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();

                Console.Write("Enter Total Seats in FirstClass: ");
                int seats = int.Parse(Console.ReadLine());

                Console.Write("Enter Total Seats in Sleeper: ");
                int seats1 = int.Parse(Console.ReadLine());

                Console.Write("Enter Total Seats in AC: ");
                int seats2 = int.Parse(Console.ReadLine());

                Console.Write("Enter the BaseCost of train: ");
                float cost = int.Parse(Console.ReadLine());

                repo.UpdateTrain(id,name, source, destination, seats, seats1, seats2, cost);
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }

        }

        public void Available()
        {
            try
            {


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("............................................................................................................");
                Console.ResetColor();
                Console.Write("Enter Train ID: ");
                int trainId = int.Parse(Console.ReadLine());

                Console.Write("Enter Travel Date (yyyy-MM-dd): ");
                DateTime travelDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Class Type (Sleeper / AC / FirstClass):");
                string classType = Console.ReadLine();
                repo.Availbility(trainId, travelDate, classType);
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
        }
    }
}


