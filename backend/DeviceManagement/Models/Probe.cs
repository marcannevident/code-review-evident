namespace DeviceManagement.Models
{
    /**
     * Represents a part attached to the device to make a quality test
     * inspection using a specific technology.
     */
    public class Probe
    {
        public string? Name { get; set; }

        public QualityTestingTypeEnum QualityTestingType { get; set; } = QualityTestingTypeEnum.Any;

        public ConnectorEnum? Connector { get; set; }
    }
}
