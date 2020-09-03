using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class FieldDetails
    {
        public FieldDetails()
        {
            SubcategoryFieldDetails = new HashSet<SubcategoryFieldDetails>();
        }

        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public int OrderValue { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual ICollection<SubcategoryFieldDetails> SubcategoryFieldDetails { get; set; }
    }
}
