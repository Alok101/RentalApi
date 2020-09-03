using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class Products
    {
        public Products()
        {
            CartItem = new HashSet<CartItem>();
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string FieldAuthor { get; set; }
        public string SoldBy { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
