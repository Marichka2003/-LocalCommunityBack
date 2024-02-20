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
    public class DepartmentsController : ControllerBase
    {
        private readonly CommunityContext _context;
        public DepartmentsController(CommunityContext context)
        {
            _context = context;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departments>>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departments>> Get(int id)
        {
            var departments = await _context.Departments.FindAsync(id);

            if (departments == null)
            {
                return NotFound();
            }

            return departments;
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<ActionResult<Departments>> Post([FromForm] DepartmentsDto departmentsDto)
        {
            var departments = new Departments
            {
                Name = departmentsDto.Name,
                Description = departmentsDto.Description,
                Type = departmentsDto.Type
            };

            _context.Departments.Add(departments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = departments.Id }, departments);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
