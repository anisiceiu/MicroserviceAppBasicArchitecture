using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Database;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderController(DatabaseContext context, IPublishEndpoint publishEndpoint)
        {
            databaseContext = context;
            _publishEndpoint = publishEndpoint; 
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<Order> PlaceOrder(Order order)
        {
            await databaseContext.Orders.AddAsync(order);
            databaseContext.SaveChanges();

            //Publish event
            await _publishEndpoint.Publish<SharedLibrary.Order>(order);

            return await Task.FromResult(order);
        }
    }
}
