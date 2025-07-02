using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  Create a class called Books with BookName and AuthorName as members. 
Instantiate the class through constructor and also write a method Display() to
display the details. 

Create an Indexer of Books Object to store 5 books in a class called BookShelf.
Using the indexer method assign values to the books and display the same.

*/
namespace Assignment5
{
    class Book
    {
        public string BookName;
        public string AuthorName;
        public  Book(string b,string a)
        {
            this.BookName = b;
            this.AuthorName = a;
        }
        public void Display()
        {
            Console.WriteLine("The name of book is {0} and author is {1}", BookName, AuthorName);
        }
    }
    class BookShelf
    {
        public Book[] books = new Book[5];
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("index are out of range");
            }
            set
            {
                if (index >= 0 && index < books.Length)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("index are out of range");
            }
        }
            public void DisplayRes()
            {
            BookShelf Books = new BookShelf();
            Books[1] = new Book("abc", "mohan");
            Books[2] = new Book("xyz", "sohan");
            Books[3] = new Book("pqr", "ram");
            Books[4] = new Book("jkl", "shyam");
            Books[0] = new Book("mno", "bahadur");
            for (int i = 0; i < 5; i++)
            {
                Books[i].Display();
            }
            }
    }
        class Question3
    {
        static void Main()
        {
            BookShelf Books = new BookShelf();
         
            Books.DisplayRes();

            Console.Read();
        }
    }
}
