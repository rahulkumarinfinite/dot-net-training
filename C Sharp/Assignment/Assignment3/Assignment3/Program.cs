using System;
/*
 * 1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
D->Deposit
W->Withdrawal

-write a function that updates the balance depending upon the transaction type

	-If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance

  function  Credit(int amount) 

	-If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance

  Debit(int amt) function 

-Pass the other information like Account no, customer name, acc type through constructor

-write and call the show data method to display the values.
*/
namespace Assignment3
{
    class Account
    {
        public double Account_no;
        public string Account_type;
        public string Customer_name;
        public float Amount;
        public float balance;
        public void debit()
        {
            Console.WriteLine("Enter the amount of withdrawal");
            float a = float.Parse(Console.ReadLine());
            balance = balance - a;
            Console.WriteLine("The available balance are : " + balance);
        }
        public void credit()
        {
            Console.WriteLine("Enter the amount of deposit");
            float a = float.Parse(Console.ReadLine());
            balance = balance + a;
            Console.WriteLine("The available balance are : " + balance);
        }
        public Account(double acc_no,string acc_type,string name)
        {
            Account_no = acc_no;
            Account_type = acc_type;
            Customer_name = name;
        }
        public void show() {
            Console.WriteLine("Account_no  =  " + Account_no + ", Account_type = " + Account_type + ",  Customer_name = " + Customer_name + ", Balance available = " + balance);
        
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(2001921530041, "Saving", "Rahul Kumar");
            Console.WriteLine("Enter D for deposit and W for the withdrawal");
            char ch = char.Parse(Console.ReadLine());
            switch (ch)
            {
                case 'D':
                    account.credit();
                    break;
                case 'W':
                    account.debit();
                    break;
                default:
                    Console.WriteLine("Enter the correct input");
                    break;
            }
            account.show();
            Console.Read();
            
        }
    }
}
