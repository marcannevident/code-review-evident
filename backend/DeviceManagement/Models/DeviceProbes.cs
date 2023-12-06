namespace DeviceManagement.Models
{
    public class DeviceProbes
    {
        public Device Device { get; set; }
        public List<Probe> CompatibleProbes { get; set; } = new List<Probe>();
    }
}
