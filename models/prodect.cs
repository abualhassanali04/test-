namespace models.prodect
{
    public class Product
    {
        public int Id;
        public string Name;
        public decimal Price;

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class Add    {
        public int add(int a, int b)
        { return a + b; }
       
    }
}