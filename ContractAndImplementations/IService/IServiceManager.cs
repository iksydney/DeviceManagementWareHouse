using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IService
{
    public interface IServiceManager
    {
        IDeviceService DeviceService { get; }
        IDeviceStatusLogService DeviceStatusLogService { get; }
    }
}
