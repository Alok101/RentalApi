using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class CategoryProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Category Category { get; set; }
        public virtual Products Product { get; set; }
    }
}
