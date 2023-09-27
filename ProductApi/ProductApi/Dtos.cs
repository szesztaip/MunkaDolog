using System.ComponentModel.DataAnnotations;

namespace ProductApi
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string Name, int Price, DateTimeOffset CreateTime);
        public record CreateProductDto(string Name, int Price);
        public record UpdateProductDto(string Name, int Price);
    }
}
