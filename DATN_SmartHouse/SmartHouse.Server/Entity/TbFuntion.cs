﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Server.Entity
{
    public partial class TbFuntion
    {
        public TbFuntion()
        {
            TbFuntionForPermissions = new HashSet<TbFuntionForPermission>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int? SortIndex { get; set; }
        public int? Version { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<TbFuntionForPermission> TbFuntionForPermissions { get; set; }
    }
}
