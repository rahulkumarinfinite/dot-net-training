using System;
/*
 *  Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
- Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as  Qty *Price
- Pass the other information like SalesNo, Productno, Price,Qty and Dateof sale through constructor
- call the show data method to display the values without an object.
*/

namespace Assignment3
{
    class Saledetails
    {
        public int Salesno;
        public int Productno;
        public int Price;
        public DateTime dateofsale;
        public int qty;
        public int Totalamount;
        public void show()
        {
            Sales();
            Console.WriteLine("Sales Number = " + Salesno + " ,Product Number = " + Productno +
                " ,Date of sales = " + dateofsale);
           
        }
        public Saledetails()
        {
            Salesno = 2;
            Productno = 5;
            dateofsale = Convert.ToDateTime("06/24/2025");
        }
        public void Sales()
        {
            Console.WriteLine("Enter the quandity of product ");
            qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Price of the product ");
            Price = int.Parse(Console.ReadLine());
            Console.WriteLine("The Total amount of the product will be ");
            Totalamount = Price * qty;
            Console.WriteLine(Totalamount);


        }
    }
    class Program3
    {
        static void Main()
        {
          
            Saledetails sale = new Saledetails();
            sale.show();
            Console.Read();
        }
    }
}
 