using CatalogService.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        public CatalogController(DatabaseContext context)
        {
            databaseContext = context;  
        }

        [HttpGet]
        [Route("GetProductList")]
        public async Task<List<Product>> GetProductList()
        {
            return await databaseContext.Products.ToListAsync();
        }
    }
}
