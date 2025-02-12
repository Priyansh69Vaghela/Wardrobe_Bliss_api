using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe_Bliss_api.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepos _orderRepos;
        public OrderController(OrderRepos orderRepos)
        {
            this._orderRepos = orderRepos;
        }

        [HttpGet]
        public IActionResult orderGet()
        {
            return Ok(_orderRepos.GetAllOrders());
        }
        [HttpGet("{id}")]
        public IActionResult orderGetByID(int id)
        {
            return Ok(_orderRepos.GetByOrderID(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderByID(int id)
        {
            return Ok(_orderRepos.DeleteOrderByID(id));
        }
        [HttpPost]
        public IActionResult InsertIntoOrder([FromBody] OrderModel order)
        {
            return Ok(_orderRepos.InsertOrder(order));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderModel order)
        {
            return Ok(_orderRepos.UpdateOrder(id, order));
        }
    }
}
