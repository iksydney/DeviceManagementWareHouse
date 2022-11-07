using ContractAndImplementations.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace DeviceAndManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public DevicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetAllDevices")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _serviceManager.DeviceService.GetAllDevices();
            return Ok(devices);
        }

        [HttpGet("{id:int}", Name = "GetDeviceById")]
        public async Task<IActionResult> GetDeviceById([FromRoute] int id)
        {
            if (id == 0)
                return NotFound();

            var device = await _serviceManager.DeviceService.GetDeviceByID(id);
            return Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceViewModel device, string userName)
        {
            var createdDevice = await _serviceManager.DeviceService.CreateDevice(device, userName);
            return CreatedAtRoute("GetDeviceById", new { id = createdDevice.Id }, createdDevice);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await _serviceManager.DeviceService.DeleteDevice(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] DeviceViewModel device)

        {
            await _serviceManager.DeviceService.UpdateDevice(id, device);
            return Ok();
        }
    }
}
