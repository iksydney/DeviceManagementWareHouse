using Entities.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class DeviceStatusLogViewModel
    {
        public int DeviceId { get; set; }
        public string Temperature { get; set; }
        public DeviceCondition DeviceCondition { get; set; }
        public DeviceCategory DeviceCategory { get; set; }
        /*public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }*/

    }
    public class StatusViewItemModel
    {
        public int StatusId { get; set; }
        public int DeviceId { get; set; }
        public string Temperature { get; set; }
        public DeviceCondition DeviceCondition { get; set; }
        public DeviceCategory DeviceCategory { get; set; }
    }
    public class StatusViewItem : StatusViewItemModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; } = DateTime.Now;

    }
    public class StatusViewFilter : StatusViewItemModel
    {
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }

        public static StatusViewFilter Deserialize(string whereCondition)
        {
            var filter = new StatusViewFilter();
            if (!string.IsNullOrEmpty(whereCondition))
            {
                filter = JsonConvert.DeserializeObject<StatusViewFilter>(whereCondition);
            }
            return filter;
        }
    }
}
