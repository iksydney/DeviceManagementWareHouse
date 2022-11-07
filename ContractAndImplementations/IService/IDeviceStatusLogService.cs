using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IService
{
    public interface IDeviceStatusLogService
    {
        Task<IEnumerable<DeviceStatusLogViewModel>> GetAllDevices();
        Task<DeviceStatusLogViewModel> GetDeviceByID(int id);
        Task<StatusViewItemModel> CreateDeviceLog(DeviceStatusLogViewModel model, string userName);
        Task DeleteDevice(int id);
        Task UpdateDevice(int Id, DeviceStatusLogViewModel model);
        Task<DeviceStatusLogViewModel> GetDeviceStatusLogByIdAsync(int DeviceStatusLogId, bool trackChanges);
        Task<IEnumerable<DeviceStatusLogViewModel>> GetDeviceByFunctionalAsync(string functional, bool trackChanges);
        Task<IEnumerable<DeviceStatusLogViewModel>> GetDeviceByFaultyAsync(string Faulty, bool trackChanges);
        Task<IEnumerable<DeviceStatusLogViewModel>> GetDeviceInRepairMode(string Repair, bool trackChanges);
    }
}
