
using testing.models;
using models.prodect;




public class Program
{
    public static void Main(string[] args)
    {
      List<Product> products = new List<Product>();
      List<Catogary> catogaries = new List<Catogary>();
while (true)
        {
            Console.WriteLine("\nmenu");
            Console.WriteLine("1-Add Product");
            Console.WriteLine("2-Add Catogary");
            Console.WriteLine("3-display all information");
            Console.WriteLine("4-Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

      

      switch (choice)
      {
          case "1":
              Console.WriteLine("Enter product details:");
              Console.Write("Id: ");
              int productId = int.Parse(Console.ReadLine());
              Console.Write("Name: ");
              string productName = Console.ReadLine();
              Console.Write("Price: ");
              decimal productPrice = decimal.Parse(Console.ReadLine());
              products.Add(new Product(productId, productName, productPrice));
              break;
          case "2":
              Console.Write("Category Id: ");
              int categoryId = int.Parse(Console.ReadLine());
              Console.Write("Category Name: ");
              string categoryName = Console.ReadLine();
              catogaries.Add(new Catogary(categoryId, categoryName));
              break;
          case "3":
          Console.WriteLine("products");
          if(products.Count == 0)
              {
                Console.WriteLine("No products available.");
              }
              else
              foreach (var product in products)
              {
                  Console.WriteLine("id : " + product.Id + " - " + product.Name + " - " + product.Price);
              }
              Console.WriteLine("category");

              if(catogaries.Count == 0)
              {
                Console.WriteLine("No categories available.");
              }
              else
              foreach (var category in catogaries)
              { 
                  Console.WriteLine("id : " + category.Id + " - " + category.Name);
              }
              break;
          case "4":
              Console.WriteLine("Exiting");
              return;
          default:
              Console.WriteLine("Invalid choice");
              break;
      }}

      /* Product p1 = new Product(1, "Laptop", 999.99m);
      Console.WriteLine(p1.Name + " - " + p1.Price);
      Catogary c1 = new Catogary(1, "Electronics");
      Console.WriteLine(c1.Name);
      Add p2 = new Add();
      Console.WriteLine(p2.add(5, 10)); */

    }
}