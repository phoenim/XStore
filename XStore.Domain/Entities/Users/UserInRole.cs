namespace XStore.Domain.Entities.Users
{
    public class UserInRole
    {
        public long Id { get; set; }

        public virtual User User { set; get; }
        public long UserId { get; set; }

        public virtual Role Role { get; set; }
        public long RoleId { get; set; }
    }
}


