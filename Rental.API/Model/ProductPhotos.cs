using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class ProductPhotos
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
        public string ThumbnailPath { get; set; }
        public string Bit { get; set; }
        public string Alt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Products Product { get; set; }
    }
}
