using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Entities
{
    public class NotificationEntity : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid ToUserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [ForeignKey("Organisation")]
        public Guid FromOrgId { get; set; }
        public UserEntity Organisation { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
