using AutoMapper;
using ContractAndImplementations.IRepository;
using ContractAndImplementations.IService;
using Entities;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _map;
        public DeviceService(IRepositoryManager repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<DeviceViewItemModel> CreateDevice(DeviceViewModel model, string userName)
        {
            var device = _map.Map<Device>(model);
            _repo.DeviceRepository.CreateDevice(device);
            device.CreatedBy = userName;
            device.UpdatedBy = userName;
            await _repo.SaveAsync();
            return _map.Map<DeviceViewItemModel>(device);
        }

        public async Task DeleteDevice(int id)
        {
            var exist = await _repo.DeviceRepository.GetDeviceByIdAsync(id, trackChanges: false);
            if (exist == null)
            {
                throw new Exception("Entity do not exist in the database");
            }
            _repo.DeviceRepository.DeleteDevice(exist);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<DeviceViewItemModel>> GetAllDevices()
        {
            var devices = await _repo.DeviceRepository.GetAllDevicesAsync(true);
            return _map.Map<IEnumerable<DeviceViewItemModel>>(devices);
        }

        public async Task<DeviceViewModel> GetDeviceByID(int id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            var deviceId = await _repo.DeviceRepository.GetDeviceByIdAsync(id, true);
            var deviceReturned = _map.Map<DeviceViewModel>(deviceId);
            return deviceReturned;
        }

        public async Task UpdateDevice(int Id, DeviceViewModel model)
        {
            var entity = await _repo.DeviceRepository.GetDeviceByIdAsync(Id, trackChanges: false);
            _map.Map(model, entity);
            await _repo.SaveAsync();
        }
    }
}
