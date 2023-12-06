using DeviceManagement.Database;
using DeviceManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDatabaseDriver _databaseDriver;

        public DeviceController(ILogger<DeviceController> logger,
            IDatabaseDriver databaseDriver)
        {
            _logger = logger;
            _databaseDriver = databaseDriver;
        }

        [HttpGet]
        public IEnumerable<Device> GetDevices()
        {
            return _databaseDriver.listDevices();
        }

        [HttpGet("/DeviceProbes")]
        public IEnumerable<DeviceProbes> GetCompatibleProbes()
        {
            var d = _databaseDriver.listDevices();

            var r = new List<DeviceProbes>();
            foreach (var de in d)
            {
                var dp = new DeviceProbes
                {
                    Device = de,
                    CompatibleProbes = new List<Probe>(),
                };

                var p = _databaseDriver.listProbes();
                foreach (var pr in p)
                {
                    if (!de.Connectors.Any(connector => pr.Connector == connector.Type))
                    {
                        continue;
                    }

                    if (de.SupportedQualityTesting != QualityTestingTypeEnum.Any && de.SupportedQualityTesting != pr.QualityTestingType)
                    {
                        continue;
                    }

                    dp.CompatibleProbes.Add(pr);                    
                }

                r.Add(dp);
            }

            return r;
        }
    }
}
