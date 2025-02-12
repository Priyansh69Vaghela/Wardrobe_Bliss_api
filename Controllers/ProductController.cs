using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe_Bliss_api.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepos _productRepos;
        public ProductController(ProductRepos productRepos)
        {
            this._productRepos = productRepos;
        }

        [HttpGet]
        public IActionResult productGet()
        {
            return Ok(_productRepos.GetAllProducts());
        }
        [HttpGet("{id}")]
        public IActionResult productGetByID(int id)
        {
            return Ok(_productRepos.GetByProductID(id));
        }
        [HttpDelete]
        public IActionResult DeleteGetByID(int id)
        {
            return Ok(_productRepos.DeleteProductByID(id));
        }
        [HttpPost]
        public IActionResult InsertIntoProduct([FromBody] ProductModel product)
        {
            return Ok(_productRepos.InsertProduct(product));
        }
        [HttpPut]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel product)
        {
            return Ok(_productRepos.UpdateProduct(id, product));
        }
    }
}
