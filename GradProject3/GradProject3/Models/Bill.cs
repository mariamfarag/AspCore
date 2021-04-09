using System;
using System.Collections.Generic;

#nullable disable

namespace GradProject3.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? Idtrade { get; set; }
        public int? Idgoods { get; set; }
        public int? Quantity { get; set; }
        public decimal? PriceForPic { get; set; }
        public DateTime? DatePayment { get; set; }

        public virtual Good IdgoodsNavigation { get; set; }
        public virtual Register IdtradeNavigation { get; set; }
    }
}
