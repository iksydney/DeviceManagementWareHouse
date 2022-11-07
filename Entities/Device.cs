using Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string Temperature { get; set; }
        public DeviceCondition DeviceCondition { get; set; }
        public DeviceCategory DeviceCategory { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
    }
}