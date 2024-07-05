﻿using System;
using System.Collections.Generic;

namespace SmartHouse.Server.Entity
{
    public partial class TbFuntionForPermission
    {
        public TbFuntionForPermission()
        {
            TbUserFuntions = new HashSet<TbUserFuntion>();
        }

        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public Guid FuntionId { get; set; }

        public virtual TbFuntion Funtion { get; set; } = null!;
        public virtual TbPermission Permission { get; set; } = null!;
        public virtual ICollection<TbUserFuntion> TbUserFuntions { get; set; }
    }
}
