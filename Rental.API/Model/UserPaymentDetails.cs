using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental.API.Model
{
    public partial class UserPaymentDetails
    {
        public int UserPaymentId { get; set; }
       
        public int UserId { get; set; }
        public string Cc { get; set; }
        public string CcNum { get; set; }
        public string HolderName { get; set; }
        public string ExpireDate { get; set; }
        public string Status { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Users User { get; set; }
    }
}
