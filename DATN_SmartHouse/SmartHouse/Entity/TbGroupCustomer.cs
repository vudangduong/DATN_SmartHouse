﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Entity
{
    public partial class TbGroupCustomer
    {
        public TbGroupCustomer()
        {
            TbCustomers = new HashSet<TbCustomer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int MinPoint { get; set; }
        public int MaxPoint { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<TbCustomer> TbCustomers { get; set; }
    }
}
