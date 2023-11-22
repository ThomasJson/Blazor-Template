using System.ComponentModel.DataAnnotations;
using Template.Domain.Common.Interfaces;

namespace Template.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}