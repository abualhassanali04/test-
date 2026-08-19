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

    }
}

   
