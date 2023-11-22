using System.ComponentModel.DataAnnotations;
using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Weight { get; set; }

        public ICollection<AccountRoleLinkEntity> AccountsLink { get; set; }
    }
}