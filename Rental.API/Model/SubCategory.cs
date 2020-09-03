using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            SubcategoryFieldDetails = new HashSet<SubcategoryFieldDetails>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string Discription { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<SubcategoryFieldDetails> SubcategoryFieldDetails { get; set; }
    }
}
