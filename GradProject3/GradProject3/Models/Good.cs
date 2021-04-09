using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GradProject3.Models
{
    public partial class Good
    {
        public Good()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }

        [DisplayName("ID Type")]
        public int? Idtg { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Product valid")]
        public string ExpireDate { get; set; }
        public string Images { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImagePath { get; set; }

        public int? Idoffers { get; set; }

        public virtual Offer IdoffersNavigation { get; set; }
        public virtual TypeGood IdtgNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
