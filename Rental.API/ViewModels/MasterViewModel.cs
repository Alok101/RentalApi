using System;
using System.Runtime.Serialization;

namespace Rental.API.ViewModels
{
    [DataContract]
    public class MasterViewModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "GroupCode")]
        public string GroupCode { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Status")]
        public string Status { get; set; }

        [DataMember(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [DataMember(Name = "ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [DataMember(Name = "IsUsed")]
        public bool IsUsed { get; set; }

        [DataMember(Name="Description")]
        public string Description { get; set; }
    }
}
