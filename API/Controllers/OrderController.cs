using Data;
using Interfaces.Application;
using Interfaces.Data;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) { 
            _orderService = orderService;
        }

        [HttpPut]
        public IActionResult Put( OrderDTO order)
        {
            return Ok(_orderService.Update(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_orderService.Delete(id));
        }


    }
}
