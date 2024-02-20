using Local_community_Back.Data;
using Local_community_Back.Model;
using Local_community_Back.ModelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Local_community_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly CommunityContext _context;

        public SubscribeController(CommunityContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] SubscribeDto model)
        {
            string email = model.Email;
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email address is required.");
            }

            // Перевірка, чи вже існує підписка з такою адресою електронної пошти
            if (_context.Subscription.Any(s => s.Email == email))
            {
                return Conflict("Email address is already subscribed.");
            }

            var subscription = new Subscription
            {
                Email = email
            };

            _context.Subscription.Add(subscription);
            await _context.SaveChangesAsync();

            return Ok("Subscription successful.");
        }

        [HttpDelete]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscribeDto model)
        {
            string email = model.Email;
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email address is required.");
            }

            var subscription = await _context.Subscription.FirstOrDefaultAsync(s => s.Email == email);
            if (subscription == null)
            {
                return NotFound("Email address is not subscribed.");
            }

            _context.Subscription.Remove(subscription);
            await _context.SaveChangesAsync();

            return Ok("Unsubscription successful.");
        }

    }
}