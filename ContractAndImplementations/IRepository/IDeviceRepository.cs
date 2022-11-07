using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IRepository
{
    public interface IDeviceRepository
    {
        void CreateDevice(Device model);
        void DeleteDevice(Device model);
        Task<IEnumerable<Device>> GetAllDevicesAsync(bool trackChanges);
        Task<Device> GetDeviceByIdAsync(int deviceId, bool trackChanges);
        Task<Device> GetDeviceByNameAsync(string name, bool trackChanges);
    }
}
