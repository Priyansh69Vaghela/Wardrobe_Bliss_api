using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe_Bliss_api.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartRepos _shoppingCartRepos;
        public ShoppingCartController(ShoppingCartRepos shoppingCartRepos)
        {
            this._shoppingCartRepos = shoppingCartRepos;
        }

        [HttpGet]
        public IActionResult GetAllCartItems()
        {
            return Ok(_shoppingCartRepos.GetAllCartItems());
        }
        [HttpGet("{id}")]
        public IActionResult GetCartByID(int id)
        {
            return Ok(_shoppingCartRepos.GetCartByID(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCart(int id)
        {
            return Ok(_shoppingCartRepos.DeleteCart(id));
        }
        [HttpPost]
        public IActionResult AddCartItem([FromBody] ShoppingCartModel CartItem)
        {
            return Ok(_shoppingCartRepos.InsertCartItem(CartItem));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCart(int id, [FromBody] ShoppingCartModel cart)
        {
            return Ok(_shoppingCartRepos.UpdateCart(id, cart));
        }
    }
}
