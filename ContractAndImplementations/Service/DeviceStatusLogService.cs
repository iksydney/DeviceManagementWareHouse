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
    public class DeviceStatusLogService : IDeviceStatusLogService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _map;
        public DeviceStatusLogService(IRepositoryManager repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<StatusViewItemModel> CreateDeviceLog(DeviceStatusLogViewModel model, string userName)
        {
            var logCreation = _map.Map<DeviceStatusLog>(model);
            _repo.DeviceStatusLogRepository.CreateDeviceStatusLog(logCreation);
            logCreation.CreatedBy = userName;
            logCreation.UpdatedBy = userName;
            await _repo.SaveAsync();
            return _map.Map<StatusViewItemModel>(model);
        }

        public async Task DeleteDevice(int id)
        {
            var exist = await _repo.DeviceStatusLogRepository.GetDeviceStatusLogByIdAsync(id, trackChanges: false);
            if (exist == null)
            {
                throw new Exception("Entity do not exist in the database");
            }
            _repo.DeviceStatusLogRepository.DeleteDeviceStatusLog(exist);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<DeviceStatusLogViewModel>> GetAllDevices()
        {
            var devices = await _repo.DeviceStatusLogRepository.GetAllDeviceStatusLogsAsync(true);
            return _map.Map<IEnumerable<DeviceStatusLogViewModel>>(devices);
        }

        public async Task<IEnumerable<DeviceStatusLogViewModel>> GetDeviceByFaultyAsync(string faulty, bool trackChanges)
        {
            if (string.IsNullOrEmpty(faulty))
                throw new Exception("Input a valid enum");
            var functionalDevices = await _repo.DeviceStatusLogRepository.GetDeviceByFaultyAsync(faulty, trackChanges);
            return _map.Map<IEnumerable<DeviceStatusLogViewModel>>(faulty);

        }

        public async Task<IEnumerable<DeviceStatusLogViewModel>> GetDeviceByFunctionalAsync(string functional, bool trackChanges)
        {
            if (string.IsNullOrEmpty(functional))
                throw new Exception("Input a valid enum");

            var functionalDevices = await _repo.DeviceStatusLogRepository.GetDeviceByFunctionalAsync(functional, trackChanges);
            return _map.Map<IEnumerable<DeviceStatusLogViewModel>>(functional);
        }

        public async Task<DeviceStatusLogViewModel> GetDeviceByID(int id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            var log = await _repo.DeviceStatusLogRepository.GetDeviceStatusLogByIdAsync(id, true);
            return _map.Map<DeviceStatusLogViewModel>(log);
        }

        public async Task<IEnumerable<DeviceStatusLogViewModel>> GetDeviceInRepairMode(string repair, bool trackChanges)
        {
            var repairModeDevices = await _repo.DeviceStatusLogRepository.GetDeviceInRepairMode(repair, trackChanges);
            return _map.Map<IEnumerable<DeviceStatusLogViewModel>>(repair);
        }

        public async Task<DeviceStatusLogViewModel> GetDeviceStatusLogByIdAsync(int deviceStatusLogId, bool trackChanges)
        {
            if (deviceStatusLogId == null)
                throw new ArgumentNullException("id");

            var log = await _repo.DeviceStatusLogRepository.GetDeviceStatusLogByIdAsync(deviceStatusLogId, true);
            return _map.Map<DeviceStatusLogViewModel>(log);
        }

        public async Task UpdateDevice(int Id, DeviceStatusLogViewModel model)
        {
            var entity = await _repo.DeviceRepository.GetDeviceByIdAsync(Id, trackChanges: false);
            _map.Map(model, entity);
            await _repo.SaveAsync();
        }
    }
}
