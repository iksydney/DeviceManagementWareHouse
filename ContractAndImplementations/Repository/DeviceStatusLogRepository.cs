using ContractAndImplementations.IRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.Repository
{
    public class DeviceStatusLogRepository : RepositoryBase<DeviceStatusLog>, IDeviceStatusLogRepository
    {
        public DeviceStatusLogRepository(RepositoryContext context) : base(context) { }

        public void CreateDeviceStatusLog(DeviceStatusLog model) => Create(model);

        public void DeleteDeviceStatusLog(DeviceStatusLog model) => Delete(model);

        public async Task<IEnumerable<DeviceStatusLog>> GetAllDeviceStatusLogsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(x => x.StatusId).ToListAsync();

        public async Task<IEnumerable<DeviceStatusLog>> GetDeviceByFaultyAsync(string Faulty, bool trackChanges) =>
            await FindAll(trackChanges)
            .Where(x => x.DeviceCondition.Equals(2)).ToListAsync();

        public async Task<IEnumerable<DeviceStatusLog>> GetDeviceByFunctionalAsync(string functional, bool trackChanges) =>
            await FindAll(trackChanges)
            .Where(x => x.DeviceCondition.Equals(1)).ToListAsync();

        public async Task<IEnumerable<DeviceStatusLog>> GetDeviceInRepairMode(string Repair, bool trackChanges) =>
            await FindAll(trackChanges)
            .Where(x => x.DeviceCondition.Equals(3)).ToListAsync();

        public async Task<DeviceStatusLog> GetDeviceStatusLogByIdAsync(int DeviceStatusLogId, bool trackChanges) =>
            await FindByCondition(c => c.StatusId.Equals(DeviceStatusLogId), trackChanges).SingleOrDefaultAsync();

    }
}
