using DeviceManagement.Database;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbeController : Controller
    {

        private readonly ILogger<ProbeController> _logger;
        private readonly IDatabaseDriver _databaseDriver;

        public ProbeController(ILogger<ProbeController> logger,
            IDatabaseDriver databaseDriver)
        {
            _logger = logger;
            _databaseDriver = databaseDriver;
        }

        [HttpGet(Name = "GetProbes")]
        public IEnumerable<Probe> Get()
        {
            return _databaseDriver.listProbes();
        }
    }
}
