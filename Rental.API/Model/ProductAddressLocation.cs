using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class ProductAddressLocation
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Status { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual AddressLocation Location { get; set; }
        public virtual Products Product { get; set; }
    }
}
