using models.prodect;
namespace testing.services
{
    public interface ICatalogService
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetProducts();
        Product? FindProduct(int id);

        void RemoveProduct(int id);
    }
}