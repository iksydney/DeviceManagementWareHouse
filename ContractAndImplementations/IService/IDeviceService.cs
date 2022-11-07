using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.IService
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceViewModel>> GetAllDevices();
        Task<DeviceViewModel> GetDeviceByID(int id);
        Task<DeviceViewItemModel> CreateDevice(DeviceViewModel model, string userName);
        Task DeleteDevice(int id);
        Task UpdateDevice(int Id, DeviceViewModel model);
    }
}
