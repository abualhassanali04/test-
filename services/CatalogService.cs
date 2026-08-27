using models;
namespace testing.services;

public class CatalogService : ICatalogService
{
    
     
    private  List<Product> _products = new List<Product>(); 
    private  List<Category> _categories = new List<Category>();

    private int _nextProductId=1;
    private int _nextCategoryId=1;

    public void AddCategory(Category category){  category.Id= _nextCategoryId;
     _categories.Add(category);
     _nextCategoryId++;}
    public void AddProduct(Product product)
    {
        product.Id=_nextProductId;
        _products.Add(product);
        _nextProductId++;}

        public bool CategoryExists(int id) => _categories.Any(c => c.Id == id);
    
    
    public IEnumerable<Product> GetProducts() => _products;

    public IEnumerable<Category> GetCategories() => _categories;

     public Product? FindProduct(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void RemoveProduct(int id) => _products.RemoveAll(p => p.Id == id);

    public IEnumerable<Product> GetProductsByCategory(int categoryId) =>
        _products.Where(p => p.CategoryId == categoryId );

    public IEnumerable<Product> SearchProductsByName(string name) =>
        _products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

    public bool UpdateProduct(int id,string name, decimal price, int stock, int categoryId)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return false;

        product.Name = name;
        product.Price = price;
        product.Stock = stock;
        product.CategoryId = categoryId;
        return true;
    }
    public decimal GetTotalInventoryValue() =>
    _products.Sum(p => p.Price * p.Stock);

    public Product? GetMostExpensiveProduct() =>
    _products.OrderByDescending(p => p.Price).FirstOrDefault();

    public IEnumerable<Product> GetOutOfStockProducts() =>
    _products.Where(p => p.Stock == 0);

    public void PrintCategoryStats()
{
    var groups = _products.GroupBy(p => p.CategoryId);

    foreach (var group in groups)
    {
        var categoryName = _categories.FirstOrDefault(c => c.Id == group.Key)?.Name ?? "Unknown";
        int count = group.Count();
        decimal avgPrice = group.Average(p => p.Price);

        Console.WriteLine($"{categoryName,-15} | Count: {count,-5} | Avg Price: {avgPrice:F2}");
    }
    
}

} 

  