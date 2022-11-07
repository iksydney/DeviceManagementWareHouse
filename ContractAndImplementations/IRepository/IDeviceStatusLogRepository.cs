using Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IRepository
{
    public interface IDeviceStatusLogRepository
    {
        void CreateDeviceStatusLog(DeviceStatusLog model);
        void DeleteDeviceStatusLog(DeviceStatusLog model);
        Task<IEnumerable<DeviceStatusLog>> GetAllDeviceStatusLogsAsync(bool trackChanges);
        Task<DeviceStatusLog> GetDeviceStatusLogByIdAsync(int DeviceStatusLogId, bool trackChanges);
        Task<IEnumerable<DeviceStatusLog>> GetDeviceByFunctionalAsync(string functional, bool trackChanges);
        Task<IEnumerable<DeviceStatusLog>> GetDeviceByFaultyAsync(string Faulty, bool trackChanges);
        Task<IEnumerable<DeviceStatusLog>> GetDeviceInRepairMode(string Repair, bool trackChanges);
    }
}
