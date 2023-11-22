using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    public class AccountRoleLinkEntity
    {
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public AccountEntity Account { get; set; }
    }
}