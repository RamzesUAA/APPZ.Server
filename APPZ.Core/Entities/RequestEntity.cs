using APPZ.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Entities
{
    public class RequestEntity : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
