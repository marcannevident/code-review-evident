namespace DeviceManagement.Models
{
    /**
     * Represents a device used to do quality testing using specific probes.
     */
    public class Device
    {
        public DateTime PurchaseDate { get; set; }

        public Guid Serial { get; set; }

        public string? Name { get; set; }

        public List<DeviceConnector> Connectors { get; set; } = new List<DeviceConnector>();

        public QualityTestingTypeEnum SupportedQualityTesting { get; set; } = QualityTestingTypeEnum.Any;

    }
}