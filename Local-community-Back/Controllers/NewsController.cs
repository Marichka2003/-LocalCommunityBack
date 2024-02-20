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
    public class NewsController : ControllerBase
    {
        private readonly CommunityContext _context;
        public NewsController(CommunityContext context)
        {
            _context = context;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {
            return await _context.News.ToListAsync();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> Get(int id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // POST api/<NewsController>
        [HttpPost]
        public async Task<ActionResult<News>> Post([FromForm] NewsDto newsDto)
        {
            var news = new News
            {
                Name = newsDto.Name,
                Description = newsDto.Description,
                ImageName = newsDto.ImageName
            };

            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = news.Id }, news);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
