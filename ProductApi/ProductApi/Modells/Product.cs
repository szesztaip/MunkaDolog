namespace ProductApi.Modells
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
