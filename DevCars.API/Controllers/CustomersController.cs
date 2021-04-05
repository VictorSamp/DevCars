using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Controllers
{
    [Route("api/customers")]
    public class CostumersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult PostOrder(int id)
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