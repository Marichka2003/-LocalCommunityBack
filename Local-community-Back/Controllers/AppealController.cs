using Local_community_Back.Data;
using Local_community_Back.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Local_community_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppealController : ControllerBase
    {
        private readonly CommunityContext _context;
        public AppealController(CommunityContext context)
        {
            _context = context;
        }

        // GET: api/<AppealController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appeal>>> Get()
        {
            return await _context.Appeal.ToListAsync();
        }

        // GET api/<AppealController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appeal>> Get(int id)
        {
            var appeal = await _context.Appeal.FindAsync(id);

            if (appeal == null)
            {
                return NotFound();
            }

            return appeal;
        }
        
        // POST api/<AppealController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppealController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppealController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
