using coreApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coreApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class BuscaPorNomeController : ControllerBase
    {
        private readonly coreApiContext _context;

        public BuscaPorNomeController(coreApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(string produto, string email)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.ToListAsync();

            if (user == null)
            {
                return NotFound(); 
            }

                return Ok(user.Where(u => u.NomeDoProduto == produto && u.Email == email));
            }
        }
    }


/*[Route("search")]
public IEnumerable<Product> GetSearch(string str)
{
    return db.Products.Where(p => p.Name.Contains(str)).ToList();
}*/