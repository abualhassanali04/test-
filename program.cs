using models;
using Validation;




public class Program
{
    public static void Main(string[] args)
    {
      List<Product> products = new List<Product>();
      List<Category> categories = new List<Category>();
while (true)
        {
            Console.WriteLine("\n\tMenu");
            Console.WriteLine("====================");
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

              int productId = InputValidator.ReadInt("Id: ");


              string productName = InputValidator.ReadNonEmptyString("Name: ");
              
              decimal productPrice = InputValidator.ReadDecimal("Price: ");
                
                int productStock = InputValidator.ReadInt("Stock: ");
                DateTime createdAt = DateTime.Now;
                
                int productCategoryId = InputValidator.ReadInt("Category Id: ");
              products.Add(new Product(productId, productName, productPrice,productStock, createdAt, productCategoryId));
              break;
          case "2":
             
              int categoryId = InputValidator.ReadInt("Category Id: ");
              
              string categoryName = InputValidator.ReadNonEmptyString("Category Name: ");
              categories.Add(new Category(categoryId, categoryName));
              break;
          case "3":
          Console.WriteLine("Displaying all information:");
          Console.WriteLine("===========================");
          Console.WriteLine("\tproducts");
          Console.WriteLine("id - name - price - stock - createdAt");
          if(products.Count == 0)
              {
                Console.WriteLine("No products available.");
              }
              else
              foreach (var product in products)
              {
                  Console.WriteLine( product.Id + " - " + product.Name + " - " + product.Price + "   -   " + product.Stock + " - " + product.CreatedAt );
              }
              Console.WriteLine("===========================");
              Console.WriteLine("\tcategories");
              Console.WriteLine("\tid - name");

              if(categories.Count == 0)
              {
                Console.WriteLine("No categories available.");
              }
              else
              foreach (var category in categories)
              { 
                  Console.WriteLine("id : " + category.Id + " - " + category.Name );
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