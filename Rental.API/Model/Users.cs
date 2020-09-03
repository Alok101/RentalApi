using System;
using System.Collections.Generic;

namespace Rental.API.Model
{
    public partial class Users
    {
        public Users()
        {
            CartItem = new HashSet<CartItem>();
            OrderProduct = new HashSet<OrderProduct>();
            UserAddress = new HashSet<UserAddress>();
            UserPaymentDetails = new HashSet<UserPaymentDetails>();
        }

        public int UserId { get; set; }
        public string SsouserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public string Status { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<UserAddress> UserAddress { get; set; }
        public virtual ICollection<UserPaymentDetails> UserPaymentDetails { get; set; }
    }
}
