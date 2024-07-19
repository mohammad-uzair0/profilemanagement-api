using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserProfileManagementApi.Data.Domain
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PortfolioUrl { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}