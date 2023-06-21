namespace ButikAPI.Models
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
