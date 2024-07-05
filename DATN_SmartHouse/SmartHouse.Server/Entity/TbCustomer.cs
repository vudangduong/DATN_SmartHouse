﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Server.Entity
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbAccounts = new HashSet<TbAccount>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public int? Rank { get; set; }
        public string? Status { get; set; }
        public DateTime? YearOfBirth { get; set; }
        public int? Sex { get; set; }
        public int? Point { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreateBy { get; set; }
        public Guid GroupCustomerId { get; set; }

        public virtual TbGroupCustomer GroupCustomer { get; set; } = null!;
        public virtual TbCustomerVoucher TbCustomerVoucher { get; set; } = null!;
        public virtual ICollection<TbAccount> TbAccounts { get; set; }
    }
}
