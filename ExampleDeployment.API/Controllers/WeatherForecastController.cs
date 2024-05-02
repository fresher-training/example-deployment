using ExampleDeployment.API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDeployment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly EDContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, EDContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "User")]
        public IEnumerable<User> Get()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<User>();
            }
        }

        [HttpPost(Name = "User")]
        public async Task<bool> Post()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    _context.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "User - " + i.ToString(),
                        Username = "username" + i.ToString(),
                    });
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
