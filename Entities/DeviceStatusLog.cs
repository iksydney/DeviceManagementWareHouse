using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DeviceStatusLog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public string Temperature { get; set; }
        public DeviceCondition DeviceCondition { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; } = DateTime.Now;

    }
}
