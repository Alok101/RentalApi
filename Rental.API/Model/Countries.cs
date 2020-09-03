using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class Countries
    {
        public Countries()
        {
            UserAddress = new HashSet<UserAddress>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual ICollection<UserAddress> UserAddress { get; set; }
    }
}
