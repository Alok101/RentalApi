using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental.API.Model
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            OrderCrossAction = new HashSet<OrderCrossAction>();
            OrderPaymentHistory = new HashSet<OrderPaymentHistory>();
        }

        public int OrderRequestId { get; set; }
        public string OrderCode { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int RequestFlowId { get; set; }
        public decimal RentPrice { get; set; }
        public int RentDays { get; set; }
        public decimal LateFees { get; set; }
        public decimal SecurityDepositAmount { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] ChangeTimeStamp { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderCrossAction> OrderCrossAction { get; set; }
        public virtual ICollection<OrderPaymentHistory> OrderPaymentHistory { get; set; }
    }
}
