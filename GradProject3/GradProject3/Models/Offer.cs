using System;
using System.Collections.Generic;

#nullable disable

namespace GradProject3.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public int? IdtyG { get; set; }
        public string Offer1 { get; set; }
        public string Size { get; set; }

        public virtual TypeGood IdtyGNavigation { get; set; }
        public virtual ICollection<Good> Goods { get; set; }
    }
}
