namespace ButikAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
