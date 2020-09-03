using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class SubcategoryFieldDetails
    {
        public int MainFieldSubcategoryId { get; set; }
        public int FieldId { get; set; }
        public int SubcategoryId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual FieldDetails Field { get; set; }
        public virtual SubCategory Subcategory { get; set; }
    }
}
