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
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(RepositoryContext context) : base(context) { }
        public void CreateDevice(Device model) => Create(model);

        public void DeleteDevice(Device model) => Delete(model);

        public async Task<IEnumerable<Device>> GetAllDevicesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(x => x.Id).ToListAsync();

        public async Task<Device> GetDeviceByIdAsync(int deviceId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(deviceId), trackChanges).SingleOrDefaultAsync();

        public async Task<Device> GetDeviceByNameAsync(string name, bool trackChanges) =>
            await FindByCondition(c => c.DeviceName.Equals(name), trackChanges).SingleOrDefaultAsync();
    }
}
