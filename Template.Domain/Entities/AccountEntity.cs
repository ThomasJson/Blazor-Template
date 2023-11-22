using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class AccountEntity : BaseAuditableEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? LastConnection { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public ICollection<AccountRoleLinkEntity> RolesLink { get; set; }
    }
}