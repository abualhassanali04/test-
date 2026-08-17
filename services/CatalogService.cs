using models.prodect;
namespace testing.services;

public class CatalogService : ICatalogService
{public void AddProduct(Product product)
    {
        
    }
 public IEnumerable<Product> GetProducts()
    {
        return Enumerable.Empty<Product>();
    }
    

public Product? FindProduct(int id)
    {
        return null;
    }

    public void RemoveProduct(int id)
    {
    }
    
} 
