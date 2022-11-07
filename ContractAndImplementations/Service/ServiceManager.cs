using AutoMapper;
using ContractAndImplementations.IRepository;
using ContractAndImplementations.IService;

namespace ContractAndImplementations.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDeviceService> _deviceService;
        private readonly Lazy<IDeviceStatusLogService> _logservice;
        public ServiceManager(IRepositoryManager repositoryManager,
            IMapper mapper)

        {
            _deviceService = new Lazy<IDeviceService>(() => new DeviceService(repositoryManager, mapper));
            _logservice = new Lazy<IDeviceStatusLogService>(() => new DeviceStatusLogService(repositoryManager, mapper));
        }
        public IDeviceService DeviceService => _deviceService.Value;

        public IDeviceStatusLogService DeviceStatusLogService => _logservice.Value;
    }
}
