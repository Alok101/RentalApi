using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class UserAddress
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Countries Country { get; set; }
        public virtual Users User { get; set; }
    }
}
