using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class OrderCrossAction
    {
        public int CrossActionId { get; set; }
        public int OrderRequestId { get; set; }
        public int ActionStatusId { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual OrderProduct OrderRequest { get; set; }
    }
}
