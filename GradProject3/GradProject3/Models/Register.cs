using System;
using System.Collections.Generic;

#nullable disable

namespace GradProject3.Models
{
    public partial class Register
    {
        public Register()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public int? IdtyReg { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ShopeName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual TypeRegister IdtyRegNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
