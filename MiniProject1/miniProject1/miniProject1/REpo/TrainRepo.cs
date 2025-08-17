using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace miniProject1.REpo
{
    class TrainRepo 
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-B9CBJ84;Initial Catalog=reservation;user id=sa;password=Ram@rti123456789");
            con.Open();
            return con;
        }

        public void ViewTrains()
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Trainss", con);
                SqlDataReader dr = cmd.ExecuteReader();

              

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("TrainId | TrainName | Source | Destination | FirstClass | Sleeper | AC | BaseCost | IsDeleted |");
                Console.ResetColor();

                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]} | {dr[1]} | {dr[2]} | {dr[3]} | {dr[4]} | {dr[5]} | {dr[6]} | {dr[7]} | {dr[8]} |");
                }
            }
        }

        public void AddTrain(string name, string source, string destination, int seats1,int seats2,int seats3,float cost)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Trainss (TrainName, Source, Destination, FirstClass,Sleeper,AC,BaseCost) VALUES (@Name, @Source, @Destination, @Seats1,@seats2,@seats3,@cost)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@Seats1", seats1);
                cmd.Parameters.AddWithValue("@seats2", seats2);
                cmd.Parameters.AddWithValue("@seats3", seats3);
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.ExecuteNonQuery();

              
            }
        }

        public void DeleteTrain(int trainId)
        {
            using (SqlConnection con = GetConnection())
            {


                SqlCommand ResCmd = new SqlCommand( "SELECT COUNT(*) FROM Reservationss WHERE TrainId=@TrainId AND DateOfTravel > @Date AND status=@status", con);
                 ResCmd.Parameters.AddWithValue("@TrainId", trainId);
                ResCmd.Parameters.AddWithValue("@Date", DateTime.Today);
                ResCmd.Parameters.AddWithValue("@status", "Confirmed");

                int flag = (int)ResCmd.ExecuteScalar();
                if (flag == 0)
                {
                    SqlCommand checkCmd = new SqlCommand("SELECT * FROM Trainss WHERE TrainId = @Id", con);
                    checkCmd.Parameters.AddWithValue("@Id", trainId);
                    SqlDataReader dr = checkCmd.ExecuteReader();
                    if (dr.Read())  
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{dr["TrainId"]} | {dr["TrainName"]} | {dr["Source"]} | {dr["Destination"]} | {dr["FirstClass"]} | {dr["Sleeper"]} | {dr["AC"]} | {dr["BaseCost"]} |");
                        Console.ResetColor();

                        dr.Close();

                        SqlCommand deleteCmd = new SqlCommand("Update Trainss set isdeleted = 1 WHERE TrainId = @Id", con);
                        deleteCmd.Parameters.AddWithValue("@Id", trainId);
                        deleteCmd.ExecuteNonQuery();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Train deleted successfully.");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Train not found.");
                        Console.ResetColor();
                        
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Train already have booking so you cannot delete the train.");
                    Console.ResetColor();

                }

            }
        }

        public void BookTicket(string name, string phone, string email, int trainId, DateTime travelDate,string classType)
        {
            using (SqlConnection con = GetConnection())
            {
                // Get Base Fare
                SqlCommand baseFareCmd = new SqlCommand("SELECT BaseCost FROM Trainss WHERE TrainId = @TrainId", con);
                baseFareCmd.Parameters.AddWithValue("@TrainId", trainId);
                float baseFare = Convert.ToSingle(baseFareCmd.ExecuteScalar());

                // Get Class Fare Multiplier
                SqlCommand fareMultiplierCmd = new SqlCommand("SELECT RateMultiplier FROM ClassFare WHERE ClassType = @ClassType", con);
                fareMultiplierCmd.Parameters.AddWithValue("@ClassType", classType);
                float multiplier = Convert.ToSingle(fareMultiplierCmd.ExecuteScalar());

                // Final Cost
                float totalCost = baseFare * multiplier;

                // Insert customer
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer (Name, Phone, MailId) VALUES (@Name, @Phone, @MailId); SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@MailId", email);
                int customerId = Convert.ToInt32(cmd.ExecuteScalar());

                // Count already booked seats
                SqlCommand seatCmd = new SqlCommand("SELECT COUNT(*) FROM Reservationss WHERE TrainId=@TrainId AND DateOfTravel=@Date AND ClassType=@classType AND status=@status", con);
                seatCmd.Parameters.AddWithValue("@TrainId", trainId);
                seatCmd.Parameters.AddWithValue("@Date", travelDate);
                seatCmd.Parameters.AddWithValue("@classType", classType);
                seatCmd.Parameters.AddWithValue("@status", "Confirmed");
                int bookedSeats = (int)seatCmd.ExecuteScalar();

                // Get total available seats
                object seatObj;
                if (classType == "Sleeper") {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT Sleeper FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                     seatObj = totalSeatCmd.ExecuteScalar();
                }
               else if (classType == "FirstClass")
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT FirstClass FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                     seatObj = totalSeatCmd.ExecuteScalar();
                }
                else if (classType == "AC")
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT AC FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0 ", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                     seatObj = totalSeatCmd.ExecuteScalar();
                }
                else 
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT Sleeper FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                    seatObj = totalSeatCmd.ExecuteScalar();
                }


                if (seatObj != null)
                {
                    int totalSeats = Convert.ToInt32(seatObj);


                    string status = bookedSeats < totalSeats ? "Confirmed" : "Waiting";
                   //int seatNumber = bookedSeats < totalSeats ? bookedSeats + 1 : 0;
                 
                      

               
                        SqlCommand bookCmd = new SqlCommand(@"INSERT INTO Reservationss (TrainId, CustomerId, DateOfTravel, TotalCost, DateOfBooking, ClassType,status)VALUES (@TrainId, @CustomerId, @DateOfTravel, @TotalCost, @DateOfBooking, @ClassType,@status)", con);

                        bookCmd.Parameters.AddWithValue("@TrainId", trainId);
                        bookCmd.Parameters.AddWithValue("@CustomerId", customerId);
                        bookCmd.Parameters.AddWithValue("@DateOfTravel", travelDate);
                        bookCmd.Parameters.AddWithValue("@TotalCost", totalCost);
                        bookCmd.Parameters.AddWithValue("@DateOfBooking", DateTime.Today);
                        bookCmd.Parameters.AddWithValue("@ClassType", classType);
                        bookCmd.Parameters.AddWithValue("@status", status);
                        bookCmd.ExecuteNonQuery();

                 

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ticket booked successfully : "+status);
                        Console.ResetColor();
                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Train not found.");
                    Console.ResetColor();
                }
            }
        }

        public void CancelTicket(int bookingId, DateTime travelDate)
        {
            using (SqlConnection con = GetConnection())
            {
                // Get refund amount
                SqlCommand costCmd = new SqlCommand("SELECT TotalCost FROM Reservationss WHERE BookingId=@Id", con);
                costCmd.Parameters.AddWithValue("@Id", bookingId);
                float AmountRefund = Convert.ToSingle(costCmd.ExecuteScalar());

                // Insert into Cancellations
                SqlCommand cancelCmd = new SqlCommand(@"INSERT INTO Cancellationss 
            (BookingId, DateOfTravel, AmtRefund, DateOfCancellation) 
            VALUES (@Id, @dt, @amt, @dc)", con);
                cancelCmd.Parameters.AddWithValue("@Id", bookingId);
                cancelCmd.Parameters.AddWithValue("@dt", travelDate);
                cancelCmd.Parameters.AddWithValue("@amt", AmountRefund * 0.5);
                cancelCmd.Parameters.AddWithValue("@dc", DateTime.Today);
                cancelCmd.ExecuteNonQuery();

                //  Cancel the ticket
                SqlCommand cancelTicketCmd = new SqlCommand("UPDATE Reservationss SET Status='Cancelled' WHERE BookingId=@Id", con);
                cancelTicketCmd.Parameters.AddWithValue("@Id", bookingId);
                int rowsAffected = cancelTicketCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ticket cancelled successfully.");
                    Console.ResetColor();

                    //  Get TrainId from cancelled booking
                    SqlCommand getTrainCmd = new SqlCommand("SELECT TrainId FROM Reservationss WHERE BookingId=@Id", con);
                    getTrainCmd.Parameters.AddWithValue("@Id", bookingId);
                    int trainId = Convert.ToInt32(getTrainCmd.ExecuteScalar());

                    //  Get classType from cancelled booking
                    SqlCommand getClassCmd = new SqlCommand("SELECT ClassType FROM Reservationss WHERE BookingId=@Id", con);
                    getClassCmd.Parameters.AddWithValue("@Id", bookingId);
                    string ClassType = Convert.ToString(getTrainCmd.ExecuteScalar());

                    //  Find the earliest waiting ticket for same train and travel date
                    SqlCommand getWaitingCmd = new SqlCommand(@"
                   SELECT TOP 1 BookingId 
                   FROM Reservationss 
                    WHERE TrainId = @TrainId AND DateOfTravel = @Date AND Status = 'Waiting' AND ClassType=@class 
                    ORDER BY BookingId ASC", con);
                    getWaitingCmd.Parameters.AddWithValue("@TrainId", trainId);
                    getWaitingCmd.Parameters.AddWithValue("@Date", travelDate);
                    getWaitingCmd.Parameters.AddWithValue("@class", ClassType);
                    object result = getWaitingCmd.ExecuteScalar();

                    //  If any waiting ticket exists, confirm it
                    if (result != null)
                    {
                        int waitingBookingId = Convert.ToInt32(result);
                        SqlCommand promoteCmd = new SqlCommand("UPDATE Reservationss SET Status='Confirmed' WHERE BookingId=@Id", con);
                        promoteCmd.Parameters.AddWithValue("@Id", waitingBookingId);
                        promoteCmd.ExecuteNonQuery();

                        Console.ForegroundColor = ConsoleColor.Yellow;  
                        Console.WriteLine($"Waiting ticket {waitingBookingId} has been promoted to Confirmed.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cancellation failed. Booking not found.");
                    Console.ResetColor();
                }
            }
        }




        //reservationReport
        public void ReservationReport(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                r.BookingId,
                t.TrainName,
                c.Name AS CustomerName,
                r.DateOfTravel,
                r.ClassType,
                r.TotalCost,
                r.Status
            FROM Reservationss r
            JOIN Trainss t ON r.TrainId = t.TrainId
            JOIN Customer c ON r.CustomerId = c.CustomerId
            WHERE r.DateOfTravel BETWEEN @start AND @end
            ORDER BY r.DateOfTravel ASC", con);

                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BookingId | TrainName | CustomerName | TravelDate | Class | Cost | Status");
                Console.ResetColor();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["BookingId"],-10} | {reader["TrainName"],-15} | {reader["CustomerName"],-15} | {Convert.ToDateTime(reader["DateOfTravel"]).ToShortDateString(),-12} | {reader["ClassType"],-10} | {reader["TotalCost"],-6} | {reader["Status"]}");
                }
            }
        }



        //Cancel Report

        public void CancelReport(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                c.BookingId,
                t.TrainName,
                cs.Name AS CustomerName,
                c.DateOfTravel,
                c.AmtRefund,
                c.DateOfCancellation
            FROM Cancellationss c
            JOIN Reservationss r ON c.BookingId = r.BookingId
            JOIN Trainss t ON r.TrainId = t.TrainId
            JOIN Customer cs ON r.CustomerId = cs.CustomerId
            WHERE c.DateOfCancellation BETWEEN @start AND @end
            ORDER BY c.DateOfCancellation ASC", con);

                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BookingId | TrainName       | CustomerName     | TravelDate  | Refund  | CancelDate");
                Console.ResetColor();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["BookingId"],-10} | {reader["TrainName"],-15} | {reader["CustomerName"],-17} | {Convert.ToDateTime(reader["DateOfTravel"]).ToShortDateString(),-11} | {reader["AmtRefund"],-7} | {Convert.ToDateTime(reader["DateOfCancellation"]).ToShortDateString()}");
                }
            }
        }


        //Update Train



        public void UpdateTrain(int trainId, string trainName, string source, string destination, int firstClassSeats, int sleeperSeats, int acSeats, float baseCost)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = @"UPDATE Trainss 
                         SET TrainName = @TrainName, 
                             Source = @Source, 
                             Destination = @Destination, 
                             FirstClass = @FirstClass, 
                             Sleeper = @Sleeper, 
                             AC = @AC, 
                             BaseCost = @BaseCost 
                         WHERE TrainId = @TrainId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@FirstClass", firstClassSeats);
                cmd.Parameters.AddWithValue("@Sleeper", sleeperSeats);
                cmd.Parameters.AddWithValue("@AC", acSeats);
                cmd.Parameters.AddWithValue("@BaseCost", baseCost);
                cmd.Parameters.AddWithValue("@TrainId", trainId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Train details updated successfully.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Update failed. Train not found.");
                }
                Console.ResetColor();
            }
        }

        public void Availbility(int trainId,DateTime travelDate,string classType)
        {
            using (SqlConnection con = GetConnection())
            {
                // Count already booked seats
                SqlCommand seatCmd = new SqlCommand("SELECT COUNT(*) FROM Reservationss WHERE TrainId=@TrainId AND DateOfTravel=@Date AND ClassType=@classType AND status=@status", con);
                seatCmd.Parameters.AddWithValue("@TrainId", trainId);
                seatCmd.Parameters.AddWithValue("@Date", travelDate);
                seatCmd.Parameters.AddWithValue("@classType", classType);
                seatCmd.Parameters.AddWithValue("@status", "Confirmed");
                int bookedSeats = (int)seatCmd.ExecuteScalar();

                // Get total available seats
                object seatObj;
                if (classType == "Sleeper")
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT Sleeper FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                    seatObj = totalSeatCmd.ExecuteScalar();
                }
                else if (classType == "FirstClass")
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT FirstClass FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                    seatObj = totalSeatCmd.ExecuteScalar();
                }
                else if (classType == "AC")
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT AC FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0 ", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                    seatObj = totalSeatCmd.ExecuteScalar();
                }
                else
                {
                    SqlCommand totalSeatCmd = new SqlCommand("SELECT Sleeper FROM Trainss WHERE TrainId=@TrainId and isdeleted = 0", con);
                    totalSeatCmd.Parameters.AddWithValue("@TrainId", trainId);
                    seatObj = totalSeatCmd.ExecuteScalar();
                }


  
               
                    int totalSeats = Convert.ToInt32(seatObj);
                    int AvailableSeat = bookedSeats < totalSeats ? totalSeats- bookedSeats  : 0;
                     Console.WriteLine("The Available seats are : " + AvailableSeat);

                }
            }



        }
}


