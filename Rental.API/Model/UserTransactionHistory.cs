using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class UserTransactionHistory
    {
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }
    }
}
