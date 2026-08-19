using models;
namespace testing.services;

public class CatalogService : ICatalogService
{
    
     
    private  List<Product> _products = new List<Product>(); 
    private  List<Category> _categories = new List<Category>();

    public void AddCategory(Category category) => _categories.Add(category);
    public void AddProduct(Product product) => _products.Add(product);
    public IEnumerable<Product> GetProducts() => _products;

    public IEnumerable<Category> GetCategories() => _categories;

     public Product? FindProduct(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public void RemoveProduct(int id) =>
            _products.RemoveAll(p => p.Id == id);
    

    
} 

  