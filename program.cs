using models;
using Validation;
using testing.services;

public class Program
{
    public static void Main(string[] args)
    {
        ICatalogService catalog = new CatalogService();

        while (true)
        {
            Console.WriteLine("\n\tMenu");
            Console.WriteLine("====================");
            Console.WriteLine("1-Add Category");
            Console.WriteLine("2-Add Product");
            Console.WriteLine("3-Display all information");
            Console.WriteLine("4-Display products by category");
            Console.WriteLine("5-Search product by name");
            Console.WriteLine("6-Update product");
            Console.WriteLine("7-Remove product");
            Console.WriteLine("8-reports");
            Console.WriteLine("9-Exit");

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
                    string categoryName = Input.ReadNonEmptyString("Category Name: ");
                    catalog.AddCategory(new Category( categoryName));
                    break;
                
                case "2":
                    if (!catalog.GetCategories().Any())
                        {
                            Console.WriteLine("No categories exist yet. Add a category first.");
                        break;
                        }

                        Console.WriteLine("Choose a category:");
                        foreach (var c in catalog.GetCategories())
                        Console.WriteLine($"{c.Id} - {c.Name}");

                        int productCategoryId;
                        while(true)
                    {
                        
                        productCategoryId  = Input.ReadInt("Category Id: ");

                       if (catalog.CategoryExists(productCategoryId))
            break;
        Console.WriteLine("This category is not available. Please enter one of the following:");
        foreach (var c in catalog.GetCategories())
            Console.WriteLine($"{c.Id} - {c.Name}");
    }

                    Console.WriteLine("Enter product details:");
                    string productName = Input.ReadNonEmptyString("Name: ");
                    decimal productPrice = Input.ReadDecimal("Price: ");
                    int productStock = Input.ReadInt("Stock: ");
                    DateTime createdAt = DateTime.Now;
                    catalog.AddProduct(new Product(productName, productPrice, productStock, productCategoryId));
                    break;


                case "3":
                    Console.WriteLine($"{"ID" , -5} | {"Product Name ",-15} | {"Price" , -10} | {"STOCk",-10} | {"CategoryName" , -15} | {"CREATED AT ",-15} ");
                    Console.WriteLine(new string('=',80));


                    if (!catalog.GetProducts().Any())
                        Console.WriteLine("No products available.");
                    else

                       foreach (var product in catalog.GetProducts())
{
                    var categor = catalog.GetCategories().FirstOrDefault(c => c.Id == product.CategoryId);
                    string categorName = categor != null ? categor.Name : "Unknown";
                    Console.WriteLine($"{product.Id,-5} | {product.Name,-15} | {product.Price,-10} | {product.Stock,-10} | {categorName,-15} | {product.CreatedAt,-15}");
}
                    Console.WriteLine($"{"CategoryId",-15} | {"CategoryName", -15}");
                    Console.WriteLine(new string('=',25));
                    if (!catalog.GetCategories().Any())
                        Console.WriteLine("No categories available.");
                    else
                        foreach (var category in catalog.GetCategories())
                            Console.WriteLine($"{category.Id,-15} | {category.Name, -15}");
                    break;

                case "4":
                    if (!catalog.GetCategories().Any())
                        {
                            Console.WriteLine("No categories exist yet. Add a category first.");
                        break;
                        }

                        Console.WriteLine("Choose a category:");
                        foreach (var c in catalog.GetCategories())
                        Console.WriteLine($"{c.Id} - {c.Name}");

                        int CategId;
                        while(true)
                    {
                        
                        CategId  = Input.ReadInt("Category Id: ");

                       if (catalog.CategoryExists(CategId))
                        break;

                        Console.WriteLine("This category is not available. Please enter one of the following:");
                        foreach (var c in catalog.GetCategories())
                        Console.WriteLine($"{c.Id} - {c.Name}");
                        }

                        Console.WriteLine($"{"ID" , -5} | {"Product Name ",-15} | {"Price" , -10} | {"STOCk",-10} | {"CREATED AT ",-15} ");
                        Console.WriteLine(new string('=',80));

                    var byCategory = catalog.GetProductsByCategory(CategId);
                    if (!byCategory.Any())
                        Console.WriteLine("No products in this category.");
                    else
                        foreach (var p in byCategory)
                            Console.WriteLine($"{p.Id,-5} | {p.Name,-15} | {p.Price,-10} | {p.Stock,-10} | {p.CreatedAt,-15}");
                    break;

                case "5":
    string searchName = Input.ReadNonEmptyString("Search By Name: ");

    Console.WriteLine($"{"ID",-5} | {"Product Name ",-15} | {"Price",-10} | {"STOCk",-10} | {"CategoryName",-15} | {"CREATED AT ",-15} ");
    Console.WriteLine(new string('=', 80));

    var searchResults = catalog.SearchProductsByName(searchName);
    if (!searchResults.Any())
        Console.WriteLine("No products found.");
    else
        foreach (var p in searchResults)
        {
            var categor = catalog.GetCategories().FirstOrDefault(c => c.Id == p.CategoryId);
            string categorName = categor != null ? categor.Name : "Unknown";
            Console.WriteLine($"{p.Id,-5} | {p.Name,-15} | {p.Price,-10} | {p.Stock,-10} | {categorName,-15} | {p.CreatedAt,-15}");
        }
    break;

                case "6":
                    int UpdateId = Input.ReadInt("Product Id to update: ");
                    if (catalog.FindProduct(UpdateId) == null)
                    {
                        Console.WriteLine("Product not found.");
                        break;
                    }
                    string newName = Input.ReadNonEmptyString("New Name: ");
                    decimal newPrice = Input.ReadDecimal("New Price: ");
                    int newStock = Input.ReadInt("New Stock: ");
                    int newCategoryId = Input.ReadInt("New Category Id: ");
                    if (!catalog.UpdateProduct(UpdateId,newName, newPrice,newStock, newCategoryId))
                    {
                        Console.WriteLine("Failed to update product.");
                    }
                    else
                    {
                        Console.WriteLine("Product updated successfully.");
                    }
                    break;
                    
                    case "7":
                    int removeId = Input.ReadInt("Product Id to Remove: ");
                    if (catalog.FindProduct(removeId) == null)
                    {
                        Console.WriteLine("Product not found.");
                        break;
                    }
                    string confirmation =Input.ReadNonEmptyString("Are you sure you want to remove this product? (y/n): ");
                    if (confirmation.ToLower() == "y")
                    {
                        catalog.RemoveProduct(removeId);
                        Console.WriteLine("Product removed successfully.");
                        break;
                    }

                        else
                    {
                        Console.WriteLine("Product removal canceled.");     
                    }
                    
                    break;
                    case "8":
                        Console.WriteLine(new string('=',84));
                        Console.WriteLine("    \tReports");
                        Console.WriteLine(new string('=',84));

                        if (!catalog.GetProducts().Any())
                            {
                                Console.WriteLine("No products available to generate reports.");
                                break;
                            }

                        decimal totalValue = catalog.GetTotalInventoryValue();
                        Console.WriteLine($"Total Inventory Value: {totalValue:F2}");
    
                        Console.WriteLine(new string('=',84));

                        Console.WriteLine();
                        var mostExpensive = catalog.GetMostExpensiveProduct();
                        Console.WriteLine($"Most Expensive Product:  {mostExpensive.Name} = {mostExpensive.Price:F2}");
    
                        Console.WriteLine(new string('=',84));

                        Console.WriteLine();
                        Console.WriteLine("Out of Stock Products:");
                        var outOfStock = catalog.GetOutOfStockProducts();
                        if (!outOfStock.Any())
                            Console.WriteLine("  None.");
                        else
                        foreach (var p in outOfStock)
                        Console.WriteLine($"  {p.Id} - {p.Name}");

                        Console.WriteLine();
                        Console.WriteLine("Category Statistics:");
                        Console.WriteLine(new string('=', 84));
                        catalog.PrintCategoryStats();

                    
                    break;

                case "9":
                    Console.WriteLine("Exiting");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}