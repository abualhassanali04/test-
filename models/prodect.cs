namespace models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }

        public Product(int id, string name, decimal price , int stock , DateTime createdAt, int categoryId )
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            CreatedAt = createdAt;
            CategoryId = categoryId;
        }
    }

   
}