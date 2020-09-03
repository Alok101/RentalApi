using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class RentDetail
    {
        public int RentDetailId { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SecurityDeposit { get; set; }
        public decimal LateFee { get; set; }
        public int CurrencyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Status { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Currencies Currency { get; set; }
    }
}
