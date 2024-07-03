using System;
using System.Collections.Generic;

namespace SmartHouse.Entity
{
    public partial class TbCart
    {
        public TbCart()
        {
            TbCartDetails = new HashSet<TbCartDetail>();
        }

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? AccountId { get; set; }
        public bool? CartAdmin { get; set; }
        public Guid? CreateBy { get; set; }

        public virtual ICollection<TbCartDetail> TbCartDetails { get; set; }
    }
}
