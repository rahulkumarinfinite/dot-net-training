using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*You have a class which has methods for transaction for a banking system. (created earlier)
•	Define your own methods for deposit money, withdraw money and balance in the account.
•	Write your own new application Exception class called InsuffientBalanceException.
•	This new Exception will be thrown in case of withdrawal of money from the account 
     where customer doesn’t have sufficient balance.
•	Identify and categorize all possible checked and unchecked exception.

*/
namespace Assignment5
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message)
        {

        }
    }
    class BankingSystem
    {
        public string name;
        public float balance;
        public BankingSystem(string n1, float f1)
        {
            this.name = n1;
            this.balance = f1;
        }
        public void deposit(float amount)
        {
            Console.WriteLine("The current balance is " + balance);
            if (amount <= 0)
                throw new ArgumentException("Enter the correct amount");
            else
                Console.WriteLine("Amount of deposit is " + amount);
                balance += amount;
        }
        public void withdrawl(float amount)
        {
            Console.WriteLine("The current balance is " + balance);
            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
            else
            {
                Console.WriteLine("The amount withdrawl is " + amount);
                balance -= amount;

            }
        }

    }
    class Question1
    {
        static void Main(string[] args)
        {
            BankingSystem bank = new BankingSystem("Rahul Kumar", 16000);
            try
            {
                bank.deposit(2000);
                bank.withdrawl(19000);
            }
            catch (InsufficientBalanceException e)
            {
                Console.WriteLine("Transaction failed: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid input: " + e.Message);
            }
            Console.WriteLine("The total balance after the transaction is " + bank.balance);
            Console.Read();

        }
    }
}