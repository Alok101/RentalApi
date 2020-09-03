using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class OrderPaymentHistory
    {
        public int PaymentHistoryId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public int OrderId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ModeOfPayment { get; set; }
        public int PaymentStatus { get; set; }
        public string Status { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual OrderProduct Order { get; set; }
    }
}
