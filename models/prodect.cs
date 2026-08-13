namespace models.prodect
{
    public class Prodect
    {
        public int Id;
        public string Name;
        public decimal Price;

        public Prodect(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
