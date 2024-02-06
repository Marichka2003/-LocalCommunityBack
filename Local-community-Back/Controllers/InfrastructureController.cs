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
    public class InfrastructureController : ControllerBase
    {
        private readonly CommunityContext _context;
        public InfrastructureController(CommunityContext context)
        {
            _context = context;
        }

        // GET: api/<InfrastructureController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infrastructure>>> Get()
        {
            return await _context.Infrastructure.ToListAsync();
        }

        // GET api/<InfrastructureController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Infrastructure>> Get(int id)
        {
            var infrastructure = await _context.Infrastructure.FindAsync(id);

            if (infrastructure == null)
            {
                return NotFound();
            }

            return infrastructure;
        }

        // POST api/<InfrastructureController>
        [HttpPost]
        public async Task<ActionResult<Infrastructure>> Post([FromForm] InfrastructureDto infrastructureDto)
        {
            var infrastructure = new Infrastructure
            {
                Name = infrastructureDto.Name,
                Type = infrastructureDto.Type,
                Adress = infrastructureDto.Adress,
                Description = infrastructureDto.Description,
                ImageName = infrastructureDto.ImageName
            };

            _context.Infrastructure.Add(infrastructure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = infrastructure.Id }, infrastructure);
        }

        // PUT api/<InfrastructureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InfrastructureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
