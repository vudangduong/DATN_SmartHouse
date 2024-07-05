﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Server.Entity
{
    public partial class TbCustomerVoucher
    {
        public Guid CustomerId { get; set; }
        public Guid VoucherId { get; set; }
        public string? VoucherCode { get; set; }

        public virtual TbCustomer Customer { get; set; } = null!;
        public virtual TbVoucher Voucher { get; set; } = null!;
    }
}
