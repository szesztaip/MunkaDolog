
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static ProductApi.Dtos;

namespace ProductApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private List<ProductDto> products = new List<ProductDto>();
        
        [HttpGet]
        public ActionResult<ProductDto> GetAll()
        {
            Connection conn = new Connection();
            products.Clear();
            try
            {
                conn.connection.Open();
                string sql = "SELECT * FROM PRODUCTS";
                MySqlCommand cmd = new MySqlCommand(sql,conn.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cucc = new ProductDto(
                        reader.GetGuid(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetDateTime(3)
                        );
                    products.Add(cucc);
                } 
                conn.connection.Close();

                return Ok(products);

            }
            catch (Exception sex)
            {
                return NotFound(sex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(Guid id) 
        {
            Connection conn = new Connection();
            products.Clear();
            try
            {
                conn.connection.Open();
                string sql = $"SELECT * FROM PRODUCTS WHERE Id='{id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                var resoult = new ProductDto(
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetDateTime(3));

                conn.connection.Close();

                return Ok(resoult);

            }
            catch (Exception sex)
            {
                return NotFound(sex);
            }
        }

        [HttpPost]
        public ActionResult<ProductDto>  PostProduct(CreateProductDto createProduct)
        {
            var product = new ProductDto(
                Guid.NewGuid(),
                createProduct.Name,
                createProduct.Price,
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
                Name = updateProduct.Name,
                Price = updateProduct.Price
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
