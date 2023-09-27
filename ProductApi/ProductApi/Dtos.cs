using System.ComponentModel.DataAnnotations;

namespace ProductApi
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreateTime);
        public record CreateProductDto([Required] string ProductName, [Range(0, 10000)] int ProductPrice);
        public record UpdateProductDto([Required] string ProductName, [Range(0, 10000)] int ProductPrice);
    }
}
