using DeviceManagement.Models;

namespace DeviceManagement.Database
{
    public interface IDatabaseDriver
    {
        IEnumerable<Probe> listProbes();
        IEnumerable<Device> listDevices();
    }
}
