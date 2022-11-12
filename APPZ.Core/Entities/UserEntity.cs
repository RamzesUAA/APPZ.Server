using APPZ.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(32)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(32)]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,32}$")]
        public string? Password { get; set; }

        public RoleName Role { get; set; }
        public ICollection<NotificationEntity> Notifications { get; set; }
    }
}
