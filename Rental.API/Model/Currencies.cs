using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class Currencies
    {
        public Currencies()
        {
            RentDetail = new HashSet<RentDetail>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual ICollection<RentDetail> RentDetail { get; set; }
    }
}
