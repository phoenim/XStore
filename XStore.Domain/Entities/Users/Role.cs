using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XStore.Domain.Entities.Users
{
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}


