using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class StatusMaster
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }
    }
}
