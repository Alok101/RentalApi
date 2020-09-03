using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class Category
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
