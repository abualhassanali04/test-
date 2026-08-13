using System;
using models.catogary;
using models.prodect;


public class Program
{
    public static void Main(string[] args)
    {
      Prodect p1 = new Prodect(1, "Laptop", 999.99m);
      Console.WriteLine(p1.Name + " - " + p1.Price);
      Catogary c1 = new Catogary(1, "Electronics");
      Console.WriteLine(c1.Name);
    }
}