using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.Product
{
    public class CreateProductRequest
    {
        [Required]
        public Guid Id { set; get; }
        [Required]
        public string? Name { set; get; }
        [Required]
        public int Price { set; get; }
        [Required]
        public string? Description { set; get; }
    }
}