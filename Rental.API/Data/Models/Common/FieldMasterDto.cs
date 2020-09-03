using System;
namespace Rental.API.Data.Models
{
    public class FieldMasterDto
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsUsed { get; set; }
        public string Description { get; set; }
    }
}
