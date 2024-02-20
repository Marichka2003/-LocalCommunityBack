using Local_community_Back.Data;
using Local_community_Back.Model;
using Local_community_Back.ModelDto;
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
        public async Task<ActionResult<Appeal>> Post([FromForm] AppealDto appealDto)
        {
            var appeal = new Appeal
            {
                FullName = appealDto.FullName,
                Adress = appealDto.Address,
                Description = appealDto.Description,
                PhoneNumber = appealDto.PhoneNumber,
                ImageName = appealDto.ImageName
            };

            if (appealDto.Type != "Appeal" && appealDto.Type != "Complaints" && appealDto.Type != "Statements" && appealDto.Type != "Proposal")
            {
                return BadRequest("Invalid appeal type.");
            }
            _context.Appeal.Add(appeal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = appeal.Id }, appeal);
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
