namespace Demo.Models
{    
    public class Product
    {
        public Guid Id { set; get; }
        public string? Name { set; get; }
        public int Price { set; get; }
        public string? Description { set; get; }
    }
}