
using Microsoft.AspNetCore.Mvc;
using static ProductApi.Dtos;

namespace ProductApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static readonly List<ProductDto> products = new()
        {
            new ProductDto(Guid.NewGuid(),"Termék1",3500,DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(),"Termék2",2500,DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(),"Termék3",1500,DateTimeOffset.UtcNow)

        };
        
        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(Guid id) 
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDto>  PostProduct(CreateProductDto createProduct)
        {
            var product = new ProductDto(
                Guid.NewGuid(),
                createProduct.ProductName,
                createProduct.ProductPrice,
                DateTimeOffset.UtcNow
                );

            products.Add(product);
            //return Created("",product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ProductDto PullProduct(Guid id, UpdateProductDto updateProduct)
        {
            var existingProduct = products.Where(x => x.Id == id).FirstOrDefault();

            var product = existingProduct with
            {
                ProductName = updateProduct.ProductName,
                ProductPrice = updateProduct.ProductPrice
            };

            var index = products.FindIndex(x => x.Id == id);
            products[index] = product;

            return products[index];
        }

        [HttpDelete("{id}")]
        public ActionResult<object> Delete(Guid id) 
        {
            var index = products.FindIndex(x=> x.Id == id);
            products.RemoveAt(index);

            if (index == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
