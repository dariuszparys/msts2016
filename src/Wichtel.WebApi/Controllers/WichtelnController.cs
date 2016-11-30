using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wichtel.Common;

namespace Wichtel.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WichtelnController: Controller
    {
        private readonly IRepository repository;
        private readonly ILogger logger;
        public WichtelnController(IRepository repository, ILoggerFactory loggerFactory)
        {
            this.repository = repository;
            this.logger = loggerFactory.CreateLogger<WichtelnController>();
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var winner = repository.LookupWinner();
            if(winner == null)
            {
                logger.LogError("Could not retrieve winner from repository");
                return BadRequest();
            }

            logger.LogInformation($"The winner is {winner.Who}");
            return Json(winner);
        }
    }
}
