using Entities.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class DeviceViewModel
    {

        public string DeviceName { get; set; }
        public string Temperature { get; set; }
        public DeviceCondition DeviceCondition { get; set; } = DeviceCondition.Functional;
        public DeviceCategory DeviceCategory { get; set; }
    }
    public class DeviceViewItemModel
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "Device Name shoould not exceed 35 characters")]
        public string? DeviceName { get; set; }
        public string? Temperature { get; set; }
        public DeviceCondition? DeviceCondition { get; set; }
        public DeviceCategory DeviceCategory { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedOn { get; set; } = DateTime.Now;
    }
    public class DeviceViewItem : DeviceViewItemModel
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        /*public DeviceCondition? DeviceStatus { get; set; }
        public DeviceCategory DeviceCategory { get; set; }*/
    }
    public class DeviceItemFilter : DeviceViewItemModel
    {
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }
        public DeviceCondition? DeviceCondition { get; set; }

        public static DeviceItemFilter Deserialize(string whereCondition)
        {
            var filter = new DeviceItemFilter();
            if (!string.IsNullOrEmpty(whereCondition))
                filter = JsonConvert.DeserializeObject<DeviceItemFilter>(whereCondition);
            return filter;
        }
    }
}
