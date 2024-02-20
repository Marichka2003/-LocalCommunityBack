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
    public class MapController : ControllerBase
    {
        private readonly CommunityContext _context;
        public MapController(CommunityContext context)
        {
            _context = context;
        }
        // GET: api/<MapController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Map>>> Get()
        {
            return await _context.Map.ToListAsync();
        }

        // GET api/<MapController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Map>> Get(int id)
        {
            var map = await _context.Map.FindAsync(id);

            if (map == null)
            {
                return NotFound();
            }

            return map;
        }

        // POST api/<MapController>
        [HttpPost]
        public async Task<ActionResult<Map>> Post([FromForm] MapDto mapDto)
        {
            var map = new Map
            {
                Name = mapDto.Name,
                Description = mapDto.Description,
                ImageName = mapDto.ImageName,
                COATUU = mapDto.COATUU,
                CATOTTG = mapDto.CATOTTG,
                Population = mapDto.Population
            };
    

            _context.Map.Add(map);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = map.Id }, map);
        }

        // PUT api/<MapController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
