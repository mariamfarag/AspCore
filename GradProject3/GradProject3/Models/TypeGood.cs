using System;
using System.Collections.Generic;

#nullable disable

namespace GradProject3.Models
{
    public partial class TypeGood
    {
        public TypeGood()
        {
            Goods = new HashSet<Good>();
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
