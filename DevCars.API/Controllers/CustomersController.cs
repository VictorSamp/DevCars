﻿using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevCars.API.Controllers
{
    [Route("api/customers")]
    public class CostumersController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;

        public CostumersController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel model)
        {
            var customer = new Customer(4, model.FullName, model.Document, model.BirthDate);

            _dbContext.Customers.Add(customer);

            return Ok();
        }

        [HttpPost("{id}/orders")]
        public IActionResult PostOrder(int id, [FromBody] AddOrderInputModel model)
        {
            var extraItems = model.ExtraItems
                .Select(e => new ExtraOrderItem(e.Description, e.Price))
                .ToList();

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar);

            var order = new Order(1, model.IdCar, model.IdCustomer, car.Price, extraItems);

            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == model.IdCustomer);

            customer.Purchase(order);

            return CreatedAtAction(
                nameof(GetOrder),
                new { id = customer.Id, orderid = order.Id },
                model
                );
        }

        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetOrder(int id, int orderId)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var order = customer.Orders.SingleOrDefault(o => o.Id == orderId);

            var extraItems = order
                .ExtraItems
                .Select(e => e.Description)
                .ToList();

            var orderViewModel = new OderDetailsViewModel(order.IdCar, order.IdCustomer, order.TotalCost, extraItems);

            return Ok(orderViewModel);
        }
    }
}