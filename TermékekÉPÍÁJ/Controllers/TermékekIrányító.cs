using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TermékekÉPÍÁJ.AdatÁtvitelTárgy;

namespace TermékekÉPÍÁJ.Controllers
{
    [Route("product")]
    [ApiController]
    public class TermékekIrányító : ControllerBase
    {
        private static readonly List<ProductAÁT> termékek = new List<ProductAÁT>()
        {
            new ProductAÁT(Guid.NewGuid(),"Termék1",3500,DateTimeOffset.UtcNow),
            new ProductAÁT(Guid.NewGuid(),"Termék2",4500,DateTimeOffset.UtcNow),
            new ProductAÁT(Guid.NewGuid(),"Termék3",5500,DateTimeOffset.UtcNow),
            new ProductAÁT(Guid.NewGuid(),"Termék4",6500,DateTimeOffset.UtcNow)
        };
        [HttpGet]
        public IEnumerable<ProductAÁT> GetbAll()
        {
            return termékek;
        }
        [HttpGet("{id")]
        public ProductAÁT GetById(Guid id)
        {
            var termék = termékek.Where(x => x.Id == id).FirstOrDefault();
            return termék;
        }
        [HttpPost]
        public CreateProductAÁT PostProduct(CreateProductAÁT prod)
        {
            var pd = new ProductAÁT(Guid.NewGuid(), prod.PName, prod.PPrice,DateTimeOffset.UtcNow);
            termékek.Add(pd);
            return prod;
        }
        [HttpPut("{id}")]
        public ProductAÁT PullProduct(Guid id, ModifyProductAÁT mod)
        {
            var existp = termékek.Where(x => x.Id == id).FirstOrDefault();
            var pr = existp with
            {
                PName = mod.PName,
                PPrice = mod.PPrice,
            };
            var index = termékek.FindIndex(x => x.Id == id);
            return termékek[index];
        }
        [HttpDelete("{id}")]
        public string Delete(Guid id)
        {
            var index = termékek.FindIndex(x=>x.Id== id);
            termékek.RemoveAt(index);
            return "De elem's been deleted";
        }
    }
}
