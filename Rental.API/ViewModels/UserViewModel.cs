using System;
using System.Runtime.Serialization;

namespace Rental.API.ViewModels
{
    [DataContract]
    public class UserViewModel
    {
        [DataMember(Name = "SSOUserId")]
        public string SsouserId { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "MiddleName")]
        public string MiddleName { get; set; }
        [DataMember(Name = "LastName")]
        public string LastName { get; set; }
        [DataMember(Name = "Dob")]
        public DateTime Dob { get; set; }
        [DataMember(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [DataMember(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy { get; set; }
        [DataMember(Name = "ModifiedOn")]
        public DateTime? ModifiedOn { get; set; }
        [DataMember(Name = "Status")]
        public string Status { get; set; }
    }
}
