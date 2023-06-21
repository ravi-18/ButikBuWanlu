namespace ButikAPI.Models.CustomModels
{
    public class TopFiveProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int QuantityIncrease { get; set; }
    }
}
