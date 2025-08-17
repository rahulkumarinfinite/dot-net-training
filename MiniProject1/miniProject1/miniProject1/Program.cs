using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniProject1.Interface;
using miniProject1.Services;



namespace miniProject1
{
        class Program
        {
        // public static TrainServices service = new TrainServices();

        public static IAdmin admin = new TrainServices();
        public static ICustomer customer = new TrainServices();

            static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("......Welcome to Railway Reservation System.........");
                Console.ResetColor();

                Console.WriteLine("Enter 'C' for customer and 'A' for admin");
                char c = char.Parse(Console.ReadLine());

                if (c == 'c' || c == 'C')
                {
                    CustomerMenu();
                }
                else if (c == 'A' || c == 'a')
                {
                    AdminMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid input");
                    Console.ResetColor();
                }

                Console.ReadLine();
            }

            static void CustomerMenu()
            {
            try
            {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("...............................Customer Menu.............................");
                    Console.ResetColor();
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("............................................................................................................");
                    Console.ResetColor();
                    Console.WriteLine("Enter 1 to View Trains");
                    Console.WriteLine("Enter 2 to Book Ticket");
                    Console.WriteLine("Enter 3 to Cancel Booking");
                    Console.WriteLine("Enter 4 to check Available seats");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 0:
                            AdminMenu();
                            break;
                        case 1:
                            customer.ViewTrains();
                            break;
                        case 2:
                            customer.BookTicket();
                            break;
                        case 3:
                            customer.CancelBooking();
                            break;
                        case 4:
                            customer.Available();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input.");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SQL Error: " + e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
            }

            static void AdminMenu()
            {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("................................Admin Menu..................................");
                Console.ResetColor();

                Console.WriteLine("Enter Admin username:");
                string username = Console.ReadLine();
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("............................................................................................................");
                    Console.ResetColor();
                    if (username == "Rahul@123")
                    {


                        Console.WriteLine("Enter 1 to Add Trains");
                        Console.WriteLine("Enter 2 to Delete Train");
                        Console.WriteLine("Enter 3 to Update train");
                        Console.WriteLine("Enter 4 to Report of Reservation Tickets");
                        Console.WriteLine("Enter 5 to Report of Cancel Tickets");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 0:
                                CustomerMenu();
                                break;
                            case 1:
                                admin.AddTrain();
                                break;
                            case 2:
                                admin.DeleteTrain();
                                break;
                            case 3:
                                admin.UpdateTrain();
                                break;
                            case 4:
                                admin.ReservationReport();
                                break;
                            case 5:
                                admin.CancelReport();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input.");
                                Console.ResetColor();
                                break;
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Admin credentials.");
                        Console.ResetColor();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SQL Error: " + e.Message);
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


