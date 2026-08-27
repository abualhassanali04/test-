using models;

namespace testing.services
{
    public interface ICatalogService
    {
        void AddProduct(Product product);
        void AddCategory(Category category);
        IEnumerable<Product> GetProducts();
        IEnumerable<Category> GetCategories();
        Product? FindProduct(int id);

        void RemoveProduct(int id);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Product> SearchProductsByName(string name);

        public bool CategoryExists(int id);

        bool UpdateProduct(int id,string name, decimal price, int stock, int categoryId);

        decimal GetTotalInventoryValue();
        Product? GetMostExpensiveProduct();
        IEnumerable<Product> GetOutOfStockProducts();

        void PrintCategoryStats();

    }
}

   
