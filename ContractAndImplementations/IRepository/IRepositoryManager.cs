using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IRepository
{
    public interface IRepositoryManager
    {
        IDeviceRepository DeviceRepository { get; }
        IDeviceStatusLogRepository DeviceStatusLogRepository { get; }
        Task SaveAsync();
    }
}
