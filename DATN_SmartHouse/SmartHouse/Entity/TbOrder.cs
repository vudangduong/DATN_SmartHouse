﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Entity
{
    public partial class TbOrder
    {
        public TbOrder()
        {
            TbOrderDetails = new HashSet<TbOrderDetail>();
        }

        public Guid Id { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? VoucherCode { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public decimal? AmountShip { get; set; }
        public decimal? TotalAmountDiscount { get; set; }
        public string? OrderCode { get; set; }
        public string? OrderCodeGhn { get; set; }
        public Guid? AddressDeliveryId { get; set; }
        public bool? OrderCounter { get; set; }
        public string? ReasionCancel { get; set; }
        public string? PhoneNumberCustomer { get; set; }
        public string? AddressCustomer { get; set; }

        public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; }
    }
}
