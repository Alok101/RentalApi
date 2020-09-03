using System;
using System.ComponentModel.DataAnnotations;

namespace Rental.API.Model
{
    public class FieldMaster
    {
       [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string GroupCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Timestamp]
        public byte[] ChangeTimeStamp { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
