using ContractAndImplementations.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAndImplementations.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IDeviceStatusLogRepository> _logRepository;
        private readonly Lazy<IDeviceRepository> _deviceRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _logRepository = new Lazy<IDeviceStatusLogRepository>((() => new DeviceStatusLogRepository(repositoryContext)));
            _deviceRepository = new Lazy<IDeviceRepository>((() => new DeviceRepository(repositoryContext)));
        }
        public IDeviceStatusLogRepository DeviceStatusLogRepository => _logRepository.Value;

        public IDeviceRepository DeviceRepository => _deviceRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
