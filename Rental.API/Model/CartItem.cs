using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental.API.Model
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
