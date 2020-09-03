using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class ProductFieldDetail
    {
        public int ProductId { get; set; }
        public int FieldId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }
        public string FieldValue { get; set; }

        public virtual FieldDetails Field { get; set; }
        public virtual Products Product { get; set; }
    }
}
