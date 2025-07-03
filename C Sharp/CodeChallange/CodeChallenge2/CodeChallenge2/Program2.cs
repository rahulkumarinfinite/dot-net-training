using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, 
 * and display the sorted Products
*/
namespace CodeChallenge2
{
    class Products
    {
        public int ProductId;
        public string ProductName;
        public float Price;
        public Products(int p1,string p2,float p3)
        {
            this.ProductId = p1;
            this.ProductName = p2;
            this.Price = p3;
        }

    }

    class Program2
    {
        static void Main() {
            Products [] ProductHouse = new Products[10];
        for(int i=0;i<10;i++){
                Console.WriteLine("input the Price of product");
                float a = float.Parse(Console.ReadLine());
                Products p1 = new Products(456,"Bajaj",a);
                ////      p1.Price = a;
                //  p1.ProductId = 456;
                //p1.ProductName = "Bajaj";
                ProductHouse[i] = p1;
            }
            Array.Sort(ProductHouse, (p1, p2) => p1.Price.CompareTo(p2.Price));
            for(int i = 0; i < 10; i++)
            {
                Products pi = ProductHouse[i];
                Console.WriteLine("Price- "+pi.Price + " ProductId- " + pi.ProductId + " Name- "+pi.ProductName);
            }
            Console.Read();

}
    }
}
