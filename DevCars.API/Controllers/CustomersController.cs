using DevCars.API.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DevCars.API.Controllers
{
    [Route("api/customers")]
    public class CostumersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel model)
        {
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult PostOrder(int id, [FromBody] AddOrderInputModel model)
        {
            return Ok();
        }

        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetOrder(int id, int orderId)
        {
            return Ok();
        }
    }
}