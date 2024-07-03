using System;
using System.Collections.Generic;

namespace SmartHouse.Entity
{
    public partial class TbColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Status { get; set; }
    }
}
