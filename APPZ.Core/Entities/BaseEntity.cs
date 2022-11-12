using System.ComponentModel.DataAnnotations;

namespace APPZ.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
