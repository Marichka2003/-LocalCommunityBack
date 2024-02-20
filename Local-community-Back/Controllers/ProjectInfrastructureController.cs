using Local_community_Back.Data;
using Local_community_Back.Model;
using Local_community_Back.ModelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Local_community_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectInfrastructureController : ControllerBase
    {
        private readonly CommunityContext _context;

        public ProjectInfrastructureController(CommunityContext context)
        {
            _context = context;
        }

        // GET: api/<ProjectInfrastructureController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectInfrasrtructure>>> Get()
        {
            return await _context.ProjectInfrasrtructure.ToListAsync();
        }

        // GET api/<ProjectInfrastructureController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectInfrasrtructure>> Get(int id)
        {
            var project = await _context.ProjectInfrasrtructure.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }

        // POST api/<ProjectInfrastructureController>
        [HttpPost]
        public async Task<ActionResult<ProjectInfrasrtructure>> Post([FromForm] ProjectDto projectDto)
        {
            var project = new ProjectInfrasrtructure
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                ImageName = projectDto.ImageName
            };

            _context.ProjectInfrasrtructure.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = project.Id }, project);
        }

        // PUT api/<ProjectInfrastructureController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectInfrasrtructure project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ProjectInfrastructureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.ProjectInfrasrtructure.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.ProjectInfrasrtructure.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.ProjectInfrasrtructure.Any(e => e.Id == id);
        }
    }
}
