using System;
using testing.models;
using models.prodect;




public class Program
{
    public static void Main(string[] args)
    {
      Product p1 = new Product(1, "Laptop", 999.99m);
      Console.WriteLine(p1.Name + " - " + p1.Price);
      Catogary c1 = new Catogary(1, "Electronics");
      Console.WriteLine(c1.Name);
      Add p2 = new Add();
      Console.WriteLine(p2.add(5, 10));

    }
}