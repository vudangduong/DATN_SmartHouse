﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Entity
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Status { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }
        public Guid? ImageId { get; set; }

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
