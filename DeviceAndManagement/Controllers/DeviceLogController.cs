using ContractAndImplementations.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace DeviceAndManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceLogController : ControllerBase
    {
        private readonly IServiceManager _service;
        public DeviceLogController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("GetAllDeviceLogs")]
        public async Task<IActionResult> GetDevices()
        {
            var deviceLogs = await _service.DeviceStatusLogService.GetAllDevices();
            return Ok(deviceLogs);
        }

        [HttpGet("{id:int}", Name = "GetDeviceLogById")]
        public async Task<IActionResult> GetDeviceLogById([FromRoute] int id)
        {
            if (id == 0)
                return NotFound();

            var device = await _service.DeviceStatusLogService.GetDeviceStatusLogByIdAsync(id, trackChanges:false);
            return Ok(device);
        }

        [HttpPost("CreateDevice")]
        public async Task<IActionResult> CreateDeviceLog([FromBody] DeviceStatusLogViewModel model, string userName)
        {
            var createdDevice = await _service.DeviceStatusLogService.CreateDeviceLog(model, userName);
            return CreatedAtRoute("GetDeviceById", new { id = createdDevice.StatusId }, createdDevice);
        }

        [HttpGet("GetFaultyDevice")]
        public async Task<IActionResult> GetFaultyDevice([FromRoute] string faulty)
        {
            var device = await _service.DeviceStatusLogService.GetDeviceByFaultyAsync(faulty, trackChanges: false);
            return Ok(device);
        }

        [HttpGet("GetFunctionalDevice")]
        public async Task<IActionResult> GetFunctionalDevice([FromRoute] string id)
        {
            var device = await _service.DeviceStatusLogService.GetDeviceByFunctionalAsync(id, trackChanges: false);
            return Ok(device);
        }

        [HttpGet("GetDevicesInRepair")]
        public async Task<IActionResult> GetDevicesInRepair([FromRoute] string id)
        {
            var device = await _service.DeviceStatusLogService.GetDeviceInRepairMode(id, trackChanges: false);
            return Ok(device);
        }
    }
}
