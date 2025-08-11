using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MiniProject
{



    class Program

    {
        
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;



        
        static void Main(string[] args)
        {




            //taking the user choice 
            Console.WriteLine("Enter 'C' for customer and 'A' for admin");
            char c = char.Parse(Console.ReadLine());
            if (c == 'c'||c=='C')
            {
                Customer();
            }
            else if (c == 'A' || c == 'a')
            {
                Admin();
            }
            Console.Read();
        }





        //user method

        public static void Customer()
        {
            Console.WriteLine("Enter 1 for Show the train");
            Console.WriteLine("Enter 2 for Book the train");
            Console.WriteLine("Enter 3 for Cancel the booking");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                ViewTrain();
            }
            else if (a == 2)
            {
                BookTicket();
            }
            else if (a == 3)
            {
                cancel();
            }
            else
            {
                Console.WriteLine("Please enter the valid Input");
            }
        }


        //Admin method
        public static void Admin()
        {
            //Add or Delete the train
            Console.WriteLine("Only Admin can Add or Delete the train ");
            Console.WriteLine("Enter the Admin user name");
            string s = Console.ReadLine();
            //check the usre input username is valid or not
            if (s == "Rahul@123")
            {
                //if valid
                Console.WriteLine("Enter the D for Delete and A for Add the train");
                char c = char.Parse(Console.ReadLine());
                if (c == 'D')
                {

                    DeleteTrain();
                }
                else if (c == 'A')
                {
                    AddTrain();
                }
                else
                {
                    Console.WriteLine("Please enter the Valid operation for the Adding and deleting the train");
                }

            }
            else
            {
                Console.WriteLine("Invalid Admin");
            }

        }





        //Connected ADO for the connection
        public static SqlConnection getdata()
        {
            con = new SqlConnection("Data Source=ICS-LT-B9CBJ84;Initial Catalog=reservation;" + "user id =sa;password=Ram@rti123456789");
            con.Open();
            return con;

        }





        //  Adding the train
        public static void AddTrain()
        {
            try
            {
                getdata();
                string name, source, destination;
                int seat;
                Console.WriteLine("Enter the name of the train");
                name = Console.ReadLine();
                Console.WriteLine("Enter the source of the train");
                source = Console.ReadLine();
                Console.WriteLine("Enter the destinatio of the train");
                destination = Console.ReadLine();
                Console.WriteLine("Enter the number of theseat in train");
                seat = int.Parse(Console.ReadLine());
                cmd = new SqlCommand("Insert into Train values(@TrainName,@Source,@Destination,@TotalSeat)");
                cmd.Connection = con;
                //input
                cmd.Parameters.AddWithValue("@TrainName", name);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@TotalSeat", seat);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Train successfully Added");

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }







        //Deleting the train
        public static void DeleteTrain()
        {
            try
            {
                con = getdata();
                Console.WriteLine("Enter TrainId to delete :");
                int id = Convert.ToInt32(Console.ReadLine());

                SqlCommand cmd1 = new SqlCommand("select * from Train where " +
                    "@id = TrainId", con);
                cmd1.Parameters.AddWithValue("@id", id);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    for (int i = 0; i < dr1.FieldCount; i++)
                    {
                        Console.Write(dr1[i] + "  ");
                    }
                    Console.WriteLine();
                }
                con.Close();

                cmd = new SqlCommand("delete from Train where TrainId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("record deleted...");
            }

            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }








        //Showing the train
        public static void ViewTrain()
        {
            try
            {
                getdata();
                cmd = new SqlCommand("Select * from Train", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "  " + dr[1] + "  " + dr[2] + "  " + dr[3] + "  " + dr[4]);
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //Book Ticket
        public static void BookTicket()
        {
           
                try
                {
                    getdata();

                    // Insert the passenger
                    Console.WriteLine("Enter the name of Passenger");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Enter the Phone number of Passenger");
                    string ph = Console.ReadLine();
                    Console.WriteLine("Enter the Email of Passenger");
                    string mail = Console.ReadLine();

                    cmd = new SqlCommand("Insert into Customer (Name,Phone,MailId) values(@Name,@Phone,@MailId); SELECT SCOPE_IDENTITY();", con);
                    cmd.Parameters.AddWithValue("@Name", pass);
                    cmd.Parameters.AddWithValue("@Phone", ph);
                    cmd.Parameters.AddWithValue("@MailId", mail);

                    object obj = cmd.ExecuteScalar(); 
                    int customerId = Convert.ToInt32(obj);

                    // Check available seat
                    Console.WriteLine("Enter the Id of train");
                    int trainId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the date of travel (yyyy-MM-dd):");
                    string dateInput = Console.ReadLine();
                    DateTime travelDate = DateTime.Parse(dateInput);

                    SqlCommand cmd2 = new SqlCommand("Select count(*) from Reservation where TrainId=@TrainId and DateOfTravel=@DateOfTravel", con);
                    cmd2.Parameters.AddWithValue("@TrainId", trainId);
                    cmd2.Parameters.AddWithValue("@DateOfTravel", travelDate);
                    int bookedSeats = (int)cmd2.ExecuteScalar();

                    SqlCommand cmd3 = new SqlCommand("Select TotalSeat from Train where TrainId=@TrainId", con);
                    cmd3.Parameters.AddWithValue("@TrainId", trainId);
                int totalSeats = 0;
                int seatNumber = 0;
                if (cmd3.ExecuteScalar()!=null)
                {
                     totalSeats = (int)cmd3.ExecuteScalar();
                     seatNumber = totalSeats > bookedSeats ? bookedSeats + 1 : 0;
                }
                else
                {
                    Console.WriteLine("No train found on given Id");
                    seatNumber = 0;

                }
            

                    // Insert into Reservation
                    if (seatNumber > 0)
                    {
                        DateTime bookingDate = DateTime.Today;
                        SqlCommand cmd4 = new SqlCommand("Insert into Reservation (TrainId, CustomerId, DateOfTravel, TotalCost, DateOfBooking) values(@TrainId, @CustomerId, @DateOfTravel, @TotalCost, @DateOfBooking)", con);
                        cmd4.Parameters.AddWithValue("@TrainId", trainId);
                        cmd4.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd4.Parameters.AddWithValue("@DateOfTravel", travelDate);
                        cmd4.Parameters.AddWithValue("@TotalCost", 1500.00);
                        cmd4.Parameters.AddWithValue("@DateOfBooking", bookingDate);
                        cmd4.ExecuteNonQuery();
                        Console.WriteLine("!! Tickets booked successfully !!");
                    }
                    else
                    {
                        Console.WriteLine("!! Sorry! No seat available !!");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Some error occurred: " + e.Message);
                }
            }


        //Cancel Tickets
        public static void cancel()
        {
            getdata();
            try
            {
                Console.WriteLine("Enter the booking id which you want to cancel");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the date of travel (yyyy-MM-dd) which you want to cancel:");
                string dateInput = Console.ReadLine();
                DateTime cancelDate = DateTime.Parse(dateInput);

                cmd = new SqlCommand("Insert into Cancellations(BookingId,AmtRefund) values (@id,@amt)",con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@amt", 750);

                SqlCommand cmd2 = new SqlCommand("Delete Reservation where BookingId=@id", con);
                cmd2.Parameters.AddWithValue("@id", id);
                int flag = cmd2.ExecuteNonQuery();
                if (flag > 0)
                {
                    Console.WriteLine("!! Tickets cancel successfully !!");
                }
                else
                {
                    Console.WriteLine("!! Tickets cancel not successfully !!");
                }
                


            }
            catch (SqlException e)
            {
                Console.WriteLine("Some error occurred :" + e.Message);
            }
        }

        }
    }


          


    

