using DeviceManagement.Models;
using System;

namespace DeviceManagement.Database
{
    public class DatabaseDriverMock : IDatabaseDriver
    {

        private static readonly string[] DeviceNames = new[]
        {
        "OmniScan X3", "OmniScan iX Pro", "Nortec 600"
        };

        private static readonly string[] ProbeNames = new[]
        {
        "X1 0LP4", "X2 0LP5", "X3 6LP6"
        };

        // Create five devices with different connectors and quality testing support.
        private static readonly IEnumerable<Device> _devices = Enumerable.Range(1, 5).Select(index =>
        {
            var connectors = GetDeviceConnectors(index);
            var supportedQualityTesting = GetQualityTestingType(index);

            var newDevice = new Device
            {
                PurchaseDate = DateTime.Now.AddMonths(-1 * index),
                Serial = Guid.NewGuid(),
                Name = DeviceNames[index % DeviceNames.Length],
                Connectors = connectors,
                SupportedQualityTesting = supportedQualityTesting,
            };

            return newDevice;
        });

        // Create five probes of varied connector and quality testing support.
        private static readonly IEnumerable<Probe> _probes = Enumerable.Range(1, 5).Select(index => new Probe
        {
            Name = ProbeNames[index % ProbeNames.Length],
            QualityTestingType = GetQualityTestingType(index),
            Connector = GetConnector(index),
        });

        public IEnumerable<Probe> listProbes()
        {
            return _probes;
        }

        public IEnumerable<Device> listDevices()
        {
            return _devices;
        }

        private static QualityTestingTypeEnum GetQualityTestingType(int index)
        {
            var values = Enum.GetValues(typeof(QualityTestingTypeEnum));
            return (QualityTestingTypeEnum)values.GetValue(index % values.Length);
        }

        private static List<DeviceConnector> GetDeviceConnectors(int index)
        {
            var nPairs = index % 2 + 1;

            var connectors = new List<DeviceConnector>();
            var connectorID = 0;
            for (var i = 0; i < nPairs; i++)
            {
                var nConnectors = index % 2 + 1;
                for (var j = 0; j < nConnectors; j++)
                {
                    connectors = connectors.Concat(
                        Enumerable.Range(1, nConnectors).Select(index => new DeviceConnector
                        {
                            ID = connectorID++,
                            Type = GetConnector(index),
                        })
                    ).ToList();
                }
            }

            return connectors;
        }

        private static ConnectorEnum GetConnector(int index)
        {
            var connectorTypes = Enum.GetValues(typeof(ConnectorEnum));
            return (ConnectorEnum)connectorTypes.GetValue(index % connectorTypes.Length);
        }
    }
}
