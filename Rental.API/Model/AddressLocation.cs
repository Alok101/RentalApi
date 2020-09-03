using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class AddressLocation
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Status { get; set; }
        public byte[] ChangeTimeStamp { get; set; }
    }
}
