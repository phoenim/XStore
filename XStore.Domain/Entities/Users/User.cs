using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Domain.Entities.Commons;

namespace XStore.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}


