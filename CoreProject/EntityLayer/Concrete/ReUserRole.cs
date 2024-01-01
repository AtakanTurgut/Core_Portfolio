using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ReUserRole : IdentityRole<int>
    {
        /*
        [Key]
        public int ReUserRoleId { get; set; }
        public string? Role { get; set; }

        public int UserId { get; set; }
        public ReUser? ReUser { get; set; }
        */
    }
}

