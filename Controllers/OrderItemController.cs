using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe_Bliss_api.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemRepos _orderItemRepos;
        public OrderItemController(OrderItemRepos orderItemRepos)
        {
            this._orderItemRepos = orderItemRepos;
        }

        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            return Ok(_orderItemRepos.GetAllOrderItems());
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderItemByID(int id)
        {
            return Ok(_orderItemRepos.GetByOrderItemID(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderByID(int id)
        {
            return Ok(_orderItemRepos.DeleteOrderItemByID(id));
        }
        [HttpPost]
        public IActionResult InsertIntoOrder([FromBody] OrderItemsModel orderItem)
        {
            return Ok(_orderItemRepos.InsertOrderItem(orderItem));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderItemsModel orderItem)
        {
            return Ok(_orderItemRepos.UpdateOrderItem(id, orderItem));
        }
    }
}
