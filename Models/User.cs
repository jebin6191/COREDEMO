using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZILDING_CORE.Models
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordKey { get; set; }
        public string ResetKey { get; set; }
        public string EmailId { get; set; }
        public long? RefId { get; set; }
        public string UserType { get; set; }
        public int? SelectedCompany { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }

    }
}
