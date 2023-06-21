namespace ButikAPI.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}