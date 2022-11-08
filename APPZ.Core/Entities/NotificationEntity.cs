using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid ToUserId { get; set; }

        [Required]
        public Guid FromOrgId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
